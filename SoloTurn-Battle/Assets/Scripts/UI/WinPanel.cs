using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _StageWInPanel;
    [SerializeField] private GameObject _stageClear;
    [SerializeField]private TurnManager _turnManager;

    private void Start()
    {
        _turnManager.OnWinPanel += OnWin;
    }



    private void OnWin()
    {
        if (GameManager.Instance._stageEnum == StageEnum.Dungeon)
        {
            _gameWinPanel.SetActive(true);
        }
        if (GameManager.Instance._stageEnum == StageEnum.Battle)
        {
            _StageWInPanel.SetActive(true);
        }
        if (GameManager.Instance._stageEnum == StageEnum.Boss)
        {
            _stageClear.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        _turnManager.OnWinPanel -= OnWin;
    }
}
