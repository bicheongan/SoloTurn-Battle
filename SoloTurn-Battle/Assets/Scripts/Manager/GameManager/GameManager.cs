using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    [SerializeField]private PlayerStates _playerStates;
    [SerializeField] private int _itemMax = 999;
    [SerializeField] private int _growthItem;
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