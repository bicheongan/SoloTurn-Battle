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

    [Header("애니메이션 및 이펙트")]
    [SerializeField] private GameObject _hitImpact;
    [SerializeField] private GameObject _attackImpact;
    [SerializeField] private GameObject _attackImpact2;
    [SerializeField] private string _attackAnimation;
    [SerializeField] private string _hitAnimation;
    [SerializeField] private string _dieAnimation;

    public string MonsterName => _monsterName;
    public GameObject Prefab => _prefab;
    public bool IsBoss => _isBoss;

    public float HP => _hp;
    public int MP => _mp;
    public float Attack => _attack;
    public float Defend => _defend;
    public int Speed => _speed;

    public GameObject HitImpact => _hitImpact;
    public GameObject AttackImpact => _attackImpact;
    public GameObject AttackImpact2 => _attackImpact2;
    public string AttackAnim => _attackAnimation;
    public string HitAnim => _hitAnimation;
    public string DieAnim => _dieAnimation;

}
