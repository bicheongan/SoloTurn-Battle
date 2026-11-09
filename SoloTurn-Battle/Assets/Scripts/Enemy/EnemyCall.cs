using System.Collections.Generic;
using UnityEngine;

public class EnemyCall : MonoBehaviour
{
    [SerializeField] private List<EnemyData> data;

    public void Enemycall()
    {
        BattleData.data = data;
        Debug.Log("콜 완료");
    }

}
