using UnityEngine;

public class TurnManager
{
    private IState _currentState;

    public IState CurrentState { get { return _currentState; } }

    public void Initialize(IState startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }
    public void ChangeState(IState nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }
}
