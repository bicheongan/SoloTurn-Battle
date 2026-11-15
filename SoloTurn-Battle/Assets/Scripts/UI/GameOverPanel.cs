using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        if (GameManager.Instance.RemainDay <= 0)
        {
            OnGameOver();
        }
    }
    private void OnGameOver()
    {
        _gameOverPanel.SetActive(true);
    }

}
