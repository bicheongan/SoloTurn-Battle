using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private TurnManager _turnManager;

    private void Start()
    {
        StartBattle();
    }

    private void StartBattle()
    {
        Debug.Log("전투 시작");

        // 추후 스테이지 데이터 가져오기
        // 추후 몬스터 스폰

        // 몬스터 생성이 끝나면 턴 시작
        _turnManager.BattleStart();
    }
}
