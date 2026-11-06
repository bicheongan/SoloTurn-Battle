using UnityEngine;

public class PlayerTurnState : IState
{
    public void Enter()
    {
        Debug.Log("플레이어 턴");
    }
    public void Execute()
    {
        Debug.Log(" 공격시 자동으로 턴 종료");
    }
    public void Exit()
    {
        Debug.Log("턴 종료 적 턴");
    }
}
