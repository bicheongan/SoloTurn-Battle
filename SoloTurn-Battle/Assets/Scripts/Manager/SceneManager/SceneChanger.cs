using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class SceneChanger : MonoBehaviour
{
    public static event Action CloseScene;
    public void SceneChange(string changeScene)
    {
        SceneManager.LoadScene(changeScene);
    }
    public void EnterBattle()
    {
        SceneManager.LoadScene("BattleScene");
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
