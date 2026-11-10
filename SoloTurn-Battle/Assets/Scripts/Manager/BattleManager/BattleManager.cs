using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Transform _playerPoint;
    [SerializeField] private GameObject _player;
    [SerializeField] private TurnManager _turnManager;
    private List<EnemyData> data;
    private List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        data = BattleData.data;
        Count();
        EnemySpawn();
        Debug.Log("적 데이터 호출");
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
            }
            else { Debug.Log("오류남 확인해봐"); }
        }
    }
    // 기본 공격
    public void PlayerAttack()
    {
        if (_turnManager.CurrentTurn != TurnEnum.PlayerTrun) return;
        if (enemies.Count == 0)
            return;

        Enemy enemy = enemies[0];// 테스트

        if (enemy.IsDead)
            return;

        enemy.TakeDamage(GameManager.Instance.PlayerStates.Attack);
        Debug.Log("플레이어 기본 공격");

        _turnManager.ChangeTurn(TurnEnum.EnemyTurn);
    }

    public void EnemyAttack()
    {
        if (enemies.Count == 0)
            return;

        Enemy enemy = enemies[0];

        if (enemy.IsDead)
            return;

        GameManager.Instance.PlayerStates.TakeDamage(enemy.Attack);
    }
}
