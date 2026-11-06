using UnityEngine;

public class BattleStartState : IState
{
    public void Enter()
    {
        Debug.Log("배틀 시작 속도 속도비교");
    }
    public void Execute()
    {
        Debug.Log(" 공격시 자동으로 턴 종료");
    }
    public void Exit()
    {
        Debug.Log("턴 종료 상대 턴");
    }
}
