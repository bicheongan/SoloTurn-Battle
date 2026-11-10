using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyData _data;
    [SerializeField]private float _currentHp;

    public float Hp => _currentHp;
    public float Attack => _data.Attack;
    public int Speed => _data.Speed;
    public bool IsDead => _currentHp <= 0;

    public void Initialize(EnemyData data)
    {
        _data = data;
        _currentHp = _data.HP;

    }
    public void TakeDamage(float damage)
    {
        damage = Mathf.Max(damage, 0f);
        _currentHp = Mathf.Max(_currentHp - damage, 0f);
    }
}