using UnityEngine;

public class GameClearPanel : MonoBehaviour
{
    [SerializeField] private GameObject _GameClear;

    private void Start()
    {
        Gameclear();
    }
    private void Gameclear()
    {
        if(GameManager.Instance.ClearCount == 4)
        {
            _GameClear.SetActive(true);
        }
    }
    public void ResetGame()
    {
        GameManager.Instance.ResetGame("MainScene");
    }
    public void ResetExit()
    {
        GameManager.Instance.ResetGame("TitleScene");
    }
}
