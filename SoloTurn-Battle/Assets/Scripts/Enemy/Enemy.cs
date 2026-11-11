using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyData _data;
    [SerializeField]private float _currentHp;

    public float Hp => _currentHp;
    public float Attack => _data.Attack;
    public int Speed => _data.Speed;
    public bool IsDead;

    public void Initialize(EnemyData data)
    {
        _data = data;
        _currentHp = _data.HP;

    }
    public void TakeDamage(float damage)
    {
        if(IsDead) return;
        damage = Mathf.Max(damage, 0f);
        _currentHp = Mathf.Max(_currentHp - damage, 0f);
        if (_currentHp <= 0) 
        {
            IsDead = true;
            Debug.Log("적 사망");
            Destroy(gameObject);
        }
    }
}