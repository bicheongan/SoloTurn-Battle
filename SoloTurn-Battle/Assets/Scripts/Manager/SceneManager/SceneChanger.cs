using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public static event Action CloseScene;
    public void SceneChange(string changeScene)
    {
        if (LoadingManager.Instance != null)
        {
            LoadingManager.Instance.StartLoading(changeScene);
        }
        else
        {
            SceneManager.LoadScene(changeScene);
        }
    }
    public void EnterBattle()
    {
        SceneChange("BattleScene");
    }
    public void CloseBattleScene()
    {
        CloseScene?.Invoke();
        SceneManager.UnloadSceneAsync("BattleScene");
    }
    public void RestNode()
    {
        CloseScene?.Invoke();
    }
}
