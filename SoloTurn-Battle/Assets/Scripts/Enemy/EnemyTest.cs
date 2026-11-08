using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private EnemyData _data;
    private float _currentHp;

    public float Hp => _currentHp;
    public int Speed => _data.Speed;
    public bool IsDead => _currentHp <= 0;

    public void Initialize(EnemyData data)
    {
        _data = data;
        _currentHp = _data.HP;
    }
}