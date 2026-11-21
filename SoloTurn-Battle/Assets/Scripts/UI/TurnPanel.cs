using System.Collections;
using UnityEngine;

public class TurnPanel : MonoBehaviour
{
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private GameObject _enemyTurn;
    [SerializeField] private GameObject _playerTurn;

    private void OnEnable()
    {
        _turnManager.OnTurnChanged += OnEnemyTurn;
        _turnManager.OnTurnChanged += OnPlayerTurn;
    }

    private void OnEnemyTurn(TurnEnum enemy)
    {
        if(enemy == TurnEnum.EnemyTurn)
        {
            StartCoroutine(EnemyPanelDelay());
        }
    }
    private IEnumerator EnemyPanelDelay()
    {
        _enemyTurn.SetActive(true);
        yield return new WaitForSeconds(1);
        _enemyTurn.SetActive(false);
    }

    private void OnPlayerTurn(TurnEnum player)
    {
        if (player == TurnEnum.PlayerTurn)
        {
            StartCoroutine(PlayerPanelDelay());
        }
    }
    private IEnumerator PlayerPanelDelay()
    {
        _playerTurn.SetActive(true);
        yield return new WaitForSeconds(1);
        _playerTurn.SetActive(false);
    }
    private void OnDisable()
    {
        _turnManager.OnTurnChanged -= OnEnemyTurn;
        _turnManager.OnTurnChanged -= OnPlayerTurn;
    }
}
