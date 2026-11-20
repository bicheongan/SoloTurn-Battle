using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    [SerializeField]private PlayerStates _playerStates;
    [SerializeField] private SkillDataList _skillDataList;
    [SerializeField] private int _itemMax = 999;
    [SerializeField] private int _growthItem;
    [SerializeField] private int _useItem = 10;
    [SerializeField] private int _totalDate = 100;
    [SerializeField]private int _clearCount;
    private SkillData _skillData;
    private int _remainDay;
    public PlayerStates PlayerStates => _playerStates;
    public SkillDataList SkillDataList => _skillDataList;
    public SkillData SkillData => _skillData;

    public int ItemMax => _itemMax;
    public int GrowthItem => _growthItem;
    public int TotalDate => _totalDate;
    public int RemainDay => _remainDay;
    public int ClearCount => _clearCount;

    // 어떤 스테이지인지 판단
    public StageEnum _stageEnum = StageEnum.None;


    private void Awake()
    {
        SetSingleton();
        _remainDay = _totalDate;
        _clearCount = 0;
    }
    public void ItemAdd()
    {
        _growthItem += GrowthItemdata.itemamount;
        if (_itemMax <= _growthItem)
        {
            _growthItem = _itemMax;
            Debug.Log("가득참");
        }
        Debug.Log(_growthItem);
    }
    public bool TrainingSucess()
    {
        bool IsSucess;
        if (_growthItem >= _useItem)
        {
            _growthItem -= _useItem;
            IsSucess = true;
        }
        else
        {
            Debug.Log("실패");
            IsSucess=false;
        }
        return IsSucess;
    }
    public bool CanLearnSkills(SkillData skilllist)
    {
        bool IsSkillSucess;
        if (_skillDataList.HasNotSkillCheck(skilllist) == true)// 중복 확인
        {
            Debug.Log("미습득 스킬");
            if (_growthItem >= skilllist.LearnCost)//재화 확인
            {
                _growthItem -= skilllist.LearnCost;
                _skillDataList.AddSkill(skilllist);
                IsSkillSucess = true;
            }
            else
            {
                Debug.Log("재화가 부족합니다.");
                IsSkillSucess = false;
            }
        }
        else
        {
            Debug.Log("중복 입니다");
            IsSkillSucess = false;
        }
        return IsSkillSucess;
    }
    public void UseTime(int usedays)
    {
        if (_remainDay > 0)
        {
            _remainDay -= usedays;
        }
    }
    public void DateCheck()
    {
        if (_remainDay <= 0)
        {
            SceneManager.LoadScene("MainScene");
            Time.timeScale = 0;
            Debug.Log("게임오버");
        }
    }
    public void ResetGame(string name)
    {
        Time.timeScale = 1;
        _remainDay = _totalDate;
        _growthItem = 0;
        _playerStates.ResetStates();
        _playerStates.Init();
        _skillDataList.SkillReset();
        _clearCount = 0;
        SceneManager.LoadScene(name);
    }
    public void AddCount()
    {
        _clearCount++;
    }
    private void SetSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _playerStates.Init();
        _playerStates.SaveBaseStates();
        DontDestroyOnLoad(gameObject);
    }
}