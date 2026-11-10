using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "RPG/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("기본 정보")]
    [SerializeField] private string _monsterName;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _isBoss;

    [Header("능력치")]
    [SerializeField] private float _hp;
    [SerializeField] private int _mp;
    [SerializeField] private float _attack;
    [SerializeField] private float _defend;
    [SerializeField] private int _speed;

    public string MonsterName => _monsterName;
    public GameObject Prefab => _prefab;
    public bool IsBoss => _isBoss;

    public float HP => _hp;
    public int MP => _mp;
    public float Attack => _attack;
    public float Defend => _defend;
    public int Speed => _speed;
}
