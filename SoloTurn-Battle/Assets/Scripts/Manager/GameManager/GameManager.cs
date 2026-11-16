using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    [SerializeField]private PlayerStates _playerStates;
    [SerializeField] private int _itemMax = 999;
    [SerializeField] private int _growthItem;
    [SerializeField] private int _useItem = 10;
    [SerializeField] private int _totalDate = 100;
    private int _remainDay;
    public PlayerStates PlayerStates => _playerStates;
    public int ItemMax => _itemMax;
    public int GrowthItem => _growthItem;
    public int TotalDate => _totalDate;
    public int RemainDay => _remainDay;

    // 어떤 스테이지인지 판단
    public StageEnum _stageEnum = StageEnum.None;


    private void Awake()
    {
        SetSingleton();
        _remainDay = _totalDate;
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

        SceneManager.LoadScene(name);
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