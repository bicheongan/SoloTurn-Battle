using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Transform _playerPoint;
    [SerializeField] private GameObject _player;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private GameObject _targetNull;
    private EnemySelect _targetEnemy;
    private bool allDead;
    public bool AllIsDead => allDead;
    private List<EnemyData> data;
    private List<Enemy> enemies = new List<Enemy>();
    private int enemycount;

    private void Awake()
    {
        data = BattleData.data;
        Count();
        EnemySpawn();
        Debug.Log("적 데이터 호출");
        _targetEnemy = GetComponent<EnemySelect>();
    }
    private void Count()
    {
        Debug.Log($"EnemyData{data.Count}");
        Debug.Log($"Transform{_spawnPoints.Count}");
    }
    private void EnemySpawn()
    {
   
        if (data.Count > _spawnPoints.Count)
        {
            Debug.Log("스폰 자리가 부족합니다.");
            return;
        }
        GameObject playerObject = Instantiate(_player, _playerPoint.position, _playerPoint.rotation);
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
        enemy.TakeDamage(GameManager.Instance.PlayerStates.Attack);
        Debug.Log("플레이어 기본 공격");

        enemycount = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy en=enemies[i];
            if (en.IsDead == false)
            {
                enemycount++;
            }
            Debug.Log(enemycount);
        }
        
        AllDead();

        _turnManager.ChangeTurn(TurnEnum.EnemyTurn);
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
    private IEnumerator SkillImpact(int slot, Enemy enemy)
    {
        Transform target = enemy.transform;
        SkillData skillData = GameManager.Instance.SkillDataList.EquipSkill[slot];
        GameObject SkillImpact = Instantiate(skillData.SkillEffect, target.position, Quaternion.identity);
        ParticleSystem Impact = SkillImpact.GetComponent<ParticleSystem>();
        SkillImpact.transform.localScale += new Vector3(1, 1, 1);
        yield return new WaitWhile(Impact.IsAlive);
        enemy.TakeDamage(GameManager.Instance.PlayerStates.Attack * skillData.Damage);
        Destroy(SkillImpact);
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
    private IEnumerator AllSkillImpact(int slot)
    {
        Transform target = _spawnPoints[0];
        SkillData skillData = GameManager.Instance.SkillDataList.EquipSkill[slot];
        GameObject SkillImpact;
        SkillImpact = Instantiate(skillData.SkillEffect, target.position, Quaternion.identity);
        ParticleSystem Impact = SkillImpact.GetComponent<ParticleSystem>();
        SkillImpact.transform.localScale += new Vector3(2.5f, 2.5f, 2.5f);

        yield return new WaitWhile(Impact.IsAlive);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].TakeDamage(GameManager.Instance.PlayerStates.Attack * skillData.Damage);
        }
        Destroy(SkillImpact);
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
    public void EnemyAttack()
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
            if (GameManager.Instance.PlayerStates.CurrentHp <= 0) 
            {
                _turnManager.BattleEnd();
                return;
            }
        }

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
            _turnManager.BattleEnd();
            return;
        }
    }
}
