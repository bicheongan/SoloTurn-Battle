using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSceneChanger : MonoBehaviour
{
    public void GameStart()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame("MainScene");
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
