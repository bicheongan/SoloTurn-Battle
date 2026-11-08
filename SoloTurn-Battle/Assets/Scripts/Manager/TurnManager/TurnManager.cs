using NUnit.Framework.Interfaces;
using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private TurnEnum _currentTurn = TurnEnum.None;

    public event Action<TurnEnum> OnTurnChanged;
    public TurnEnum CurrentTurn { get { return _currentTurn; } }

    public void ChangeTurn(TurnEnum newTurn)
    {
        if (_currentTurn == newTurn)
            return;

        _currentTurn = newTurn;

        OnTurnChanged?.Invoke(_currentTurn);
    }
}
