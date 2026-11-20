using UnityEngine;

[CreateAssetMenu(fileName ="NewSkill", menuName ="Skill/Skill Data")]
public class SkillData : ScriptableObject
{
    [Header("스킬 이름")]
    [SerializeField] private string _skillName;

    [Header("스킬 Mp소모량 및 데미지")]
    [SerializeField] private float _damage;
    [SerializeField] private int _mpCost;

    [Header("스킬 습득 비용")]
    [SerializeField] private int _learnCost;

    [Header(" 전체공격 스킬 여부")]
    [SerializeField] private bool _canAllTarget;
    
    [Header("애니메이션 및 효과")]
    [SerializeField] private Sprite _skillIcon;
    [SerializeField] private GameObject _skillEffect;
    [SerializeField] private GameObject _skillEffect2;
    [SerializeField] private string _animationName;

    public string SkillName => _skillName;
    public float Damage => _damage;
    public int MPCost => _mpCost;
    public bool CanAllTarget => _canAllTarget;
    public int LearnCost { get { return _learnCost; } set { _learnCost = value; } }
    public Sprite SkillIcon => _skillIcon;
    public GameObject SkillEffect => _skillEffect;
    public GameObject SkillEffect2 => _skillEffect2;
    public string AnimationName => _animationName;
}
