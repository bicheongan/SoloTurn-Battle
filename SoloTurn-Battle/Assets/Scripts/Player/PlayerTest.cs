using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _maxMp = 50;
    [SerializeField] private int _attack = 10;
    [SerializeField] private int _defense = 5;
    [SerializeField] private int _speed = 5;

    public int Hp => _maxHp;
    public int Mp => _maxMp;

    public int Speed => _speed;
}
