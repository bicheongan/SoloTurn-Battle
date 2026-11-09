using NUnit.Framework.Interfaces;
using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private TurnEnum _currentTurn = TurnEnum.None;
    [SerializeField]private PlayerTest _playerTest;
    [SerializeField]private Enemy _enemyTest;

    public event Action<TurnEnum> OnTurnChanged;
    public TurnEnum CurrentTurn { get { return _currentTurn; } }


    public void BattleStart()
    {
        if (_playerTest.Speed >= _enemyTest.Speed)
        {
            ChangeTurn(TurnEnum.PlayerTrun);
            Debug.Log("플레이어 턴");
        }
        else
        {
            ChangeTurn(TurnEnum.EnemyTurn);
            Debug.Log("적 턴");
        }
    }
    public void ChangeTurn(TurnEnum newTurn)
    {
        if (_currentTurn == newTurn)
            return;

        _currentTurn = newTurn;

        OnTurnChanged?.Invoke(_currentTurn);
    }
    public void BattleEnd()
    {
        if (_playerTest.Hp <= 0 || _enemyTest.Hp <= 0)
        {
            ChangeTurn(TurnEnum.PlayerTrun);
        }
        else
        {
            ChangeTurn(TurnEnum.EnemyTurn);
        }
    }
}
