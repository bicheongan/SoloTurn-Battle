using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Transform _playerPoint;
    [SerializeField] private GameObject _player;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private GameObject _targetNull;
    [SerializeField] private List<Button> _button;
    [SerializeField] private CinemachineCamera _playerCloseUpCamera;
    [SerializeField] private CinemachineCamera _allEnemyUpCamera;
    [SerializeField] private CinemachineCamera _EnemyCloseUpCamera;
    [SerializeField]private GameObject _attackImpact;
    [SerializeField] private String _normalAnim;
    private EnemySelect _targetEnemy;
    private bool allDead;
    public bool AllIsDead => allDead;
    private List<EnemyData> data;
    private List<Enemy> enemies = new List<Enemy>();
    private int enemycount;
    private Animator _playerAnimator;
    private Quaternion _playerTransform;
    private Transform _playerLook;
    private void Awake()
    {
        data = BattleData.data;
        Count();
        PlayerEnemySpawn();
        Debug.Log("적 데이터 호출");
        _targetEnemy = GetComponent<EnemySelect>();
    }
    private void Count()
    {
        Debug.Log($"EnemyData{data.Count}");
        Debug.Log($"Transform{_spawnPoints.Count}");
    }
    private void PlayerEnemySpawn()
    {
   
        if (data.Count > _spawnPoints.Count)
        {
            Debug.Log("스폰 자리가 부족합니다.");
            return;
        }
        GameObject playerObject = Instantiate(_player, _playerPoint.position, _playerPoint.rotation);
        _playerAnimator = playerObject.GetComponent<Animator>();
        _playerLook = playerObject.transform;
        _playerTransform = playerObject.transform.rotation;
        for (int i = 0; i < data.Count; i++)
        {
            GameObject enemyObject = Instantiate(data[i].Prefab, _spawnPoints[i].position, _spawnPoints[i].rotation);
            Enemy enemy = enemyObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemies.Add(enemy);
                enemy.Initialize(data[i]);
                enemy.LookPlayer(_playerPoint);
            }
            else { Debug.Log("오류남 확인해봐"); }
        }
    }
    // 기본 공격
    public void PlayerAttack()
    {
        if (GameManager.Instance.PlayerStates.CurrentHp <= 0) return;
        if (_turnManager.CurrentTurn != TurnEnum.PlayerTurn) return;
        if (enemies.Count == 0)return;
        Enemy enemy = _targetEnemy.Target;
        if (_targetEnemy.Target == null)
        {
            _targetNull.SetActive(true);
            StartCoroutine(targetPanel());
            return;
        }
        if (enemy.IsDead) return;
        StartCoroutine(NormalImpact(enemy));
        Debug.Log("플레이어 기본 공격");
    }
    public void PlayerSkillAttack(int slotnum)
    {
        SkillData skillData = GameManager.Instance.SkillDataList.EquipSkill[slotnum];// 슬롯정보 받기
        if (GameManager.Instance.PlayerStates.CurrentHp <= 0) return;
        if (skillData == null) return;
        if (GameManager.Instance.PlayerStates.CurrentMp < skillData.MPCost) return;
        if (_turnManager.CurrentTurn != TurnEnum.PlayerTurn) return;
        if (enemies.Count == 0) return;

        Enemy enemy = _targetEnemy.Target;
        if (skillData.CanAllTarget == true)
        {
            StartCoroutine(AllSkillImpact(slotnum));
            Debug.Log("플레이어 전체공격 스킬");
        }
        else
        {
            if (_targetEnemy.Target == null)
            {
                _targetNull.SetActive(true);
                StartCoroutine(targetPanel());
                return;
            }
            if (enemy.IsDead) return;
            StartCoroutine(SkillImpact(slotnum, enemy));
            Debug.Log("플레이어 단일공격 스킬");
        }
        GameManager.Instance.PlayerStates.CurrentMp -= skillData.MPCost;

    }
    private IEnumerator NormalImpact(Enemy enemy)
    {
        {
            Transform target = enemy.transform;
            FalseButton();
            _playerLook.transform.LookAt(target);
            _playerAnimator.Play(_normalAnim);
            yield return new WaitForSeconds(0.47f);
            GameObject SkillImpact = Instantiate(_attackImpact, target.position, Quaternion.identity);
            ParticleSystem Impact = SkillImpact.GetComponent<ParticleSystem>();
            SkillImpact.transform.localScale += new Vector3(1, 1, 1);
            yield return new WaitWhile(Impact.IsAlive);
            enemy.TakeDamage(GameManager.Instance.PlayerStates.Attack);
            Destroy(SkillImpact);
            _playerLook.rotation = _playerTransform;
            TrueButton();
            enemycount = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy en = enemies[i];
                if (en.IsDead == false)
                {
                    enemycount++;
                }
                Debug.Log(enemycount);
            }
            AllDead();

            _turnManager.ChangeTurn(TurnEnum.EnemyTurn);
        }
    }
    private IEnumerator SkillImpact(int slot, Enemy enemy)
    {
        Transform target = enemy.transform;
        SkillData skillData = GameManager.Instance.SkillDataList.EquipSkill[slot];
        FalseButton();

        _playerLook.transform.LookAt(target);// 스킬 사용시 지정 몬스터를 바라본다.

        // 스킬데이터에 저장된 애니메이션과 이펙트를 재생
        _playerAnimator.Play(GameManager.Instance.SkillDataList.EquipSkill[slot].AnimationName);
        GameObject SkillImpact2 = Instantiate(skillData.SkillEffect2, _playerPoint.position, Quaternion.identity);
        ParticleSystem Impact2 = SkillImpact2.GetComponent<ParticleSystem>();
        yield return new WaitWhile(Impact2.IsAlive);

        // 지정 몬스터로 카메라 전환
        _EnemyCloseUpCamera.Target.TrackingTarget = target;
        _EnemyCloseUpCamera.Priority = 80;

        // 몬스터 위치에 이펙트 생성
        GameObject SkillImpact = Instantiate(skillData.SkillEffect, target.position, Quaternion.identity);
        ParticleSystem Impact = SkillImpact.GetComponent<ParticleSystem>();
        SkillImpact.transform.localScale += new Vector3(1, 1, 1);
        yield return new WaitWhile(Impact.IsAlive);

        // 이펙트 재생 후 데미지 전당
        enemy.TakeDamage(GameManager.Instance.PlayerStates.Attack * skillData.Damage);
        Destroy(SkillImpact);

        // 저장된 플레이어가 바라보는 방향 원위치 및 카메라 전환
        _playerLook.rotation = _playerTransform;
        _EnemyCloseUpCamera.Priority = 0;
        TrueButton();

        // 몬스터 전원 사망인지 체크
        enemycount = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy en = enemies[i];
            if (en.IsDead == false)
            {
                enemycount++;
            }
            Debug.Log(enemycount);
        }
        AllDead();

        // 턴전환
        _turnManager.ChangeTurn(TurnEnum.EnemyTurn);
    }
    private IEnumerator AllSkillImpact(int slot)
    {
        Transform target = _spawnPoints[0];
        SkillData skillData = GameManager.Instance.SkillDataList.EquipSkill[slot];
        FalseButton();
        GameObject SkillImpact;
        GameObject SkillImpact2;
        _playerCloseUpCamera.Priority = 70;
        _playerAnimator.Play(GameManager.Instance.SkillDataList.EquipSkill[slot].AnimationName);
        SkillImpact2 = Instantiate(skillData.SkillEffect2, _playerPoint.position, Quaternion.identity);
        ParticleSystem Impact2 = SkillImpact2.GetComponent<ParticleSystem>();
        yield return new WaitWhile(Impact2.IsAlive);
        _allEnemyUpCamera.Priority = 80;
        SkillImpact = Instantiate(skillData.SkillEffect, target.position, Quaternion.identity);
        ParticleSystem Impact = SkillImpact.GetComponent<ParticleSystem>();
        SkillImpact.transform.localScale += new Vector3(3.5f, 3.5f, 3.5f);

        yield return new WaitWhile(Impact.IsAlive);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].TakeDamage(GameManager.Instance.PlayerStates.Attack * skillData.Damage);
        }
        Destroy(SkillImpact);
        Destroy(SkillImpact2);
        TrueButton();
        _playerCloseUpCamera.Priority = 0;
        _allEnemyUpCamera.Priority = 0;
        enemycount = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy en = enemies[i];
            if (en.IsDead == false)
            {
                enemycount++;
            }
            Debug.Log(enemycount);
        }
        AllDead();

        _turnManager.ChangeTurn(TurnEnum.EnemyTurn);
    }

    // 몬스터턴에 몬스터들 공격
    private void EnemyAttack()
    {
        if (enemies.Count == 0) return;
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy enemy = enemies[i];
            if (enemies[i].IsDead)
            {
                continue;
            }

            Debug.Log("총공격!!!");
            GameManager.Instance.PlayerStates.TakeDamage(enemy.Attack);
        }

    }
    private void EnemyTurn(TurnEnum turn)
    {
        if (AllIsDead) return;
        if (turn == TurnEnum.EnemyTurn)
        {

            EnemyAttack();
            Debug.Log("몬스터 공격");
            if (GameManager.Instance.PlayerStates.IsDead)
            {
                _turnManager.ChangeTurn(TurnEnum.BattleEnd);
                _turnManager.BattleEnd(false);
                return;
            }
            if (GameManager.Instance.PlayerStates.IsDead) return;
            _turnManager.ChangeTurn(TurnEnum.PlayerTurn);
            Debug.Log("플레이어 턴");
        }
        else if (turn == TurnEnum.PlayerTurn)
        {
            Debug.Log("플레이어 대기");
        }
    }
    private void OnEnable()
    {
        _turnManager.OnTurnChanged += EnemyTurn;
    }
    private void OnDisable()
    {
        _turnManager.OnTurnChanged -= EnemyTurn;
    }
    private IEnumerator targetPanel()
    {
        yield return new WaitForSeconds(1);
        _targetNull.SetActive(false);
    }
    public void AllDead()
    {
        if (enemycount == 0)
        {
            allDead = true;
            Debug.Log("전멸");
            _turnManager.ChangeTurn(TurnEnum.BattleEnd);
            _turnManager.BattleEnd(true);
            return;
        }
    }
    private void FalseButton()
    {
        for (int i = 0; i < _button.Count; i++)
        {
            _button[i].interactable = false;
        }
    }
    private void TrueButton()
    {
        for (int i = 0; i < _button.Count; i++)
        {
            _button[i].interactable = true;
        }
    }
}
