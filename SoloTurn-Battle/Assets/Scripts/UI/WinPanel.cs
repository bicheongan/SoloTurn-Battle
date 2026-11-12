using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField]private TurnManager _turnManager;

    private void Start()
    {
        _turnManager.OnWinPanel += OnWin;
    }



    private void OnWin()
    {
        _gameWinPanel.SetActive(true);
    }
    private void OnDestroy()
    {
        _turnManager.OnWinPanel -= OnWin;
    }
}
