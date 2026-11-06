using UnityEngine;

public class BattleEndState : IState
{
    public void Enter()
    {
        Debug.Log("몬스터가 없거나 플레이어 사망");
    }
    public void Execute()
    {
        Debug.Log("승리 또는 패배 패널 활성화 후 버튼 누르면 상태 종료");
    }
    public void Exit()
    {
        Debug.Log("배틀 종료");
    }
}
