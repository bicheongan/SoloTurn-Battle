using System;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class PlayerStates
{
    [Header("기초 스탯")]
    [SerializeField] private float _maxHp = 100; //최대 채력
    [SerializeField] private float _currentHp;
    [SerializeField] private int _maxMp = 50; // 최대 mp
    [SerializeField] private int _currentMp = 50;
    [SerializeField] private float _attack = 10;
    [SerializeField] private float _defend = 5;
    [SerializeField] private int _speed = 5;
    
    [Header("강화 최대치")]
    [SerializeField] private float _maxTrainingHp = 500;
    [SerializeField] private int _maxTrainingMp = 500;
    [SerializeField] private float _maxTrainingAttack = 500;
    [SerializeField] private float _maxTrainingDefend = 500;
    [SerializeField] private int _maxTrainingSpeed = 500;

    public float MaxTrainingHp => _maxTrainingHp;
    public int MaxTrainingMp => _maxTrainingMp;
    public float MaxTrainingAttack => _maxTrainingAttack;
    public float MaxTrainingDefend => _maxTrainingDefend;
    public int MaxTrainingSpeed => _maxTrainingSpeed;



    [Header("강화량")]
    [SerializeField] private float _trainingMaxHp = 10;
    [SerializeField] private int _trainingMaxMp = 10;
    [SerializeField] private float _trainingAttack = 10;
    [SerializeField] private float _trainingDefend = 10;
    [SerializeField] private int _trainingSpeed = 10;
    public float TrainingMaxHp => _trainingMaxHp;
    public int TrainingMaxMp => _trainingMaxMp;
    public float TrainingAttack => _trainingAttack;
    public float TrainingDefend => _trainingDefend;
    public int TrainingSpeed => _trainingSpeed;

    [Header("최대강화 여부체크")]
    [SerializeField] private bool _istrainingMaxHp;
    [SerializeField] private bool _istrainingMaxMp;
    [SerializeField] private bool _istrainingAttack;
    [SerializeField] private bool _istrainingDefend;
    [SerializeField] private bool _istrainingSpeed;
    public bool IstrainingMaxHp => _istrainingMaxHp;
    public bool IstrainingMaxMp => _istrainingMaxMp;
    public bool IstrainingAttack => _istrainingAttack;
    public bool IstrainingDefend => _istrainingDefend;
    public bool IstrainingSpeed => _istrainingSpeed;
    public float MaxHp => _maxHp;
    public float CurrentHp { get { return _currentHp; } set { _currentHp = value; } }
    public int MaxMp => _maxMp;
    public int CurrentMp { get { return _currentMp; } set { _currentMp = value; } }
    public float Attack => _attack;
    public float Defense => _defend;
    public int Speed => _speed;
    public bool IsDead => _currentHp <= 0;
    private EnumStates _stateType = EnumStates.None;
    private IsMax _ismax = IsMax.None;

    //스탯 저장 데이터
    private float _saveHp;
    private int _saveMp;
    private float _saveAttack;
    private float _saveDefend;
    private int _saveSpeed;

    public void Init()
    {
        _currentHp = _maxHp;
        _currentMp = _maxMp;
    }
    public void TakeDamage(float damage)
    {
        damage = Mathf.Max(damage * (100f / (100f + _defend)), 0f);
        _currentHp = Mathf.Max(_currentHp - (int)damage, 0f);
    }
    public void SaveBaseStates()
    {
        _saveHp = _maxHp;
        _saveMp = _maxMp;
        _saveAttack = _attack;
        _saveDefend = _defend;
        _saveSpeed = _speed;
    }
    public void ResetStates()
    {
        _maxHp = _saveHp;
        _maxMp = _saveMp;
        _attack = _saveAttack;
        _defend = _saveDefend;
        _speed = _saveSpeed;

        _istrainingMaxHp = false;
        _istrainingMaxMp = false;
        _istrainingAttack = false;
        _istrainingDefend = false;
        _istrainingSpeed = false;
    }
    public void TrainngState()
    {
        if(_stateType == EnumStates.MaxHp)
        {
            if (_maxHp <= _maxTrainingHp)
            {
                _maxHp += _trainingMaxHp;
                _currentHp += _trainingMaxHp;
            }
            if(_maxHp >= _maxTrainingHp)
            {
                _maxHp = _maxTrainingHp;
                _istrainingMaxHp = true;
                Debug.Log("최대강화");
            }

            return;
        }
        if (_stateType == EnumStates.MaxMp)
        { 
            if (_maxMp <= _maxTrainingMp)
            {
                _maxMp += _trainingMaxMp;
                _currentMp += _trainingMaxMp;
            }
            if( _maxMp >= _maxTrainingMp)
            {
                _maxMp = _maxTrainingMp;
                _istrainingMaxMp = true;
                Debug.Log("최대강화");
            }
            return;
        }
        if (_stateType == EnumStates.Attack)
        {
            if (_attack <= _maxTrainingAttack)
            {
                _attack += _trainingAttack;
            }
            if(_attack >= _maxTrainingAttack)
            {
                _attack = _maxTrainingAttack;
                _istrainingAttack = true;
                Debug.Log("최대강화");
            }
            return;
        }
        if (_stateType == EnumStates.Defend)
        {
            if (_defend <= _maxTrainingDefend)
            {
                _defend += _trainingDefend;
            }
            if (_defend >= _maxTrainingDefend)
            {
                _defend = _maxTrainingDefend;
                _istrainingDefend = true;
                Debug.Log("최대강화");
            }
            return;
        }
        if (_stateType == EnumStates.Speed)
        {
            if (_speed <= _maxTrainingSpeed)
            {
                _speed += _trainingSpeed;
            }
            if(_speed >= _maxTrainingSpeed)
            {
                _speed = _maxTrainingSpeed;
                _istrainingSpeed = true;
                Debug.Log("최대강화");
            }
            return;
        }
    }
    public bool IsCanNot()
    {
        bool IsNot;
        if(_ismax == IsMax.IsMaxHp)
        {
            if (_istrainingMaxHp == true)
            {
                IsNot = true;
                return IsNot;
            }
        }
        if(_ismax == IsMax.IsMaxMp)
        {
            if (_istrainingMaxMp == true)
            {
                IsNot = true;
                return IsNot;
            }
        }
        if(_ismax == IsMax.IsMaxAttack)
        {
            if (_istrainingAttack == true)
            {
                IsNot = true;
                return IsNot;
            }
        }
        if(_ismax == IsMax.IsMaxDefend)
        {
            if (_istrainingDefend == true)
            {
                IsNot = true;
                return IsNot;
            }
        }
        if(_ismax == IsMax.IsMaxSpeed)
        {
            if (_istrainingSpeed == true)
            {
                IsNot = true;
                return IsNot;
            }
        }
        return false;

    }
    public void ChangeEnumState(EnumStates newstate)
    {
        if (_stateType == newstate)
            return;

        _stateType = newstate;
    }
    public void ChangeIsMax(IsMax newismax)
    {
        if (_ismax == newismax)
            return;

        _ismax = newismax;
    }
}
