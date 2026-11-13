using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    [SerializeField]private PlayerStates _playerStates;
    [SerializeField] private int _itemMax = 999;
    [SerializeField] private int _growthItem;
    [SerializeField] private int _useItem = 10;
    public PlayerStates PlayerStates => _playerStates;
    public int ItemMax => _itemMax;
    public int GrowthItem => _growthItem;


    private void Awake()
    {
        SetSingleton();
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
    private void SetSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _playerStates.Init();
        DontDestroyOnLoad(gameObject);
    }
}