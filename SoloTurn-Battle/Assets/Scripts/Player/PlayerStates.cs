using System;
using UnityEngine;

[Serializable]
public class PlayerStates
{
    [SerializeField] private float _maxHp = 100;
    [SerializeField] private float _currentHp;
    [SerializeField] private int _maxMp = 50;
    [SerializeField] private int _currentMp = 50;
    [SerializeField] private float _attack = 10;
    [SerializeField] private float _defend = 5;
    [SerializeField] private int _speed = 5;
    public float MaxHp => _maxHp;
    public float CurrentHp => _currentHp;
    public int MaxMp => _maxMp;
    public int CurrentMp => _currentMp;
    public float Attack => _attack;
    public float Defense => _defend;
    public int Speed => _speed;
    public bool IsDead => _currentHp <= 0;

    public void Init()
    {
        _currentHp = _maxHp;
        _currentMp = _maxMp;
    }
}
