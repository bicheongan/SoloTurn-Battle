using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class SceneChanger : MonoBehaviour
{
    public void SceneChange(string changeScene)
    {
        SceneManager.LoadScene(changeScene);
    }
    public void EnterBattle()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
