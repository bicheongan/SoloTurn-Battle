using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyData _data;
    [SerializeField]private float _currentHp;

    public float Hp => _currentHp;
    public int Speed => _data.Speed;
    public bool IsDead => _currentHp <= 0;

}