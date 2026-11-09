using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _maxMp = 50;
    [SerializeField] private int _attack = 10;
    [SerializeField] private int _defense = 5;
    [SerializeField] private int _speed = 5;

    private int _currentHp;
    private int _currentMp;

    public int Speed => _speed;
    public int Hp => _maxHp;

    private void Awake()
    {
        _currentHp = _maxHp;
        _currentMp = _maxMp;
    }
}