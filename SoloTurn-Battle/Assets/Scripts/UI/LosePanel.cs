using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TurnManager _turnManager;

    private void Start()
    {
        _turnManager.OnLosePanel += OnLose;
    }

    private void OnLose()
    {
        _losePanel.SetActive(true);
    }
    private void OnDestroy()
    {
        _turnManager.OnLosePanel -= OnLose;
    }
}
