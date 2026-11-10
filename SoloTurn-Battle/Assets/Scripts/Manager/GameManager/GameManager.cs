using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    [SerializeField]private PlayerStates _playerStates;
    public PlayerStates PlayerStates => _playerStates;


    private void Awake()
    {
        SetSingleton();
        _playerStates.Init();
        Debug.Log(PlayerStates.CurrentHp);
    }

    private void SetSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
