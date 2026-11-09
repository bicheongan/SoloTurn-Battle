using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    private List<EnemyData> data;

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
        for (int i = 0; i < data.Count; i++)
        {
            EnemyData enemy = Instantiate(data[i], _spawnPoints[i].position, _spawnPoints[i].rotation);
        }
    }
}
