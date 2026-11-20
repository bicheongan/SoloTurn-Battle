using System.Runtime.CompilerServices;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField]private GameObject _stageLosePanel;
    [SerializeField] private TurnManager _turnManager;

    private void Start()
    {
        _turnManager.OnLosePanel += OnLose;
    }

    private void OnLose()
    {
        if (GameManager.Instance._stageEnum == StageEnum.Dungeon)
        {
            _losePanel.SetActive(true);
        }
        if (GameManager.Instance._stageEnum == StageEnum.Battle || GameManager.Instance._stageEnum == StageEnum.Boss)
        {
            _stageLosePanel.SetActive(true);
        }
    
    }
    private void OnDestroy()
    {
        _turnManager.OnLosePanel -= OnLose;
    }
}
