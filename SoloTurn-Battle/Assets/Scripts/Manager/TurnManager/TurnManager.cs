using System;
using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private BattleManager _battleManager;
    private List<EnemyData> data;
    private PlayerStates player;
    private int _maxSpeed;
    private TurnEnum _currentTurn = TurnEnum.None;
    public event Action<TurnEnum> OnTurnChanged;
    public TurnEnum CurrentTurn { get { return _currentTurn; } }

    private void Start()
    {
        player = GameManager.Instance.PlayerStates;
        data = BattleData.data;
        MaxSpeed();
        BattleStart();
        Debug.Log(_maxSpeed);
        Debug.Log(player);
        Debug.Log(player.Speed);
    }

    public void BattleStart()
    {
        if (player.Speed >= _maxSpeed)
        {
            ChangeTurn(TurnEnum.PlayerTurn);
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

        if (_battleManager.AllIsDead) return;
        if (_currentTurn == TurnEnum.EnemyTurn)
        {

            _battleManager.EnemyAttack();
            Debug.Log("몬스터 공격");
            if (GameManager.Instance.PlayerStates.IsDead)
            {
                ChangeTurn(TurnEnum.BattleEnd);
                BattleEnd();
            }
            if (GameManager.Instance.PlayerStates.IsDead) return;
            ChangeTurn(TurnEnum.PlayerTurn);
            Debug.Log("플레이어 턴");
        }
        else if (_currentTurn == TurnEnum.PlayerTurn)
        {
            Debug.Log("플레이어 대기");
        }
    }
    public event Action OnWinPanel;
    public event Action OnLosePanel;
    public void BattleEnd()
    {
        if (GameManager.Instance.PlayerStates.IsDead)
        {
            Debug.Log(" 플레이어 사망");
            Debug.Log("졌당ㅠㅠ");

            OnLosePanel?.Invoke();

            //패배패널 띄우기
            return;

        }
        if (_battleManager.AllIsDead)
        {
            Debug.Log("d이겼당");

            OnWinPanel?.Invoke();

            return;
        }
        
        // BattleManager에서 몬스터가 모두 죽었다고 알리면 승리 패널을 띄운다.
    }
    public void MaxSpeed()
    {
        if (data == null) return;
        _maxSpeed = 0;
        int MidSpeed;
        for (int i = 0; i < data.Count; i++)
        {
            MidSpeed = data[i].Speed;
            if (MidSpeed > _maxSpeed)
            {
                _maxSpeed = MidSpeed;
            }
        }
    }
}
