using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSceneChanger : MonoBehaviour
{
    [SerializeField]private GameObject _allObject;

    private void Start()
    {
        SceneChanger.CloseScene += OnObject;
    }

    public void LoadBattleScene()
    {
        StartCoroutine(BattleLoadDelay());
    }
    private IEnumerator BattleLoadDelay()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        yield return op;
        _allObject.SetActive(false);
    }
    private void OnObject()
    {
        _allObject.SetActive(true);
    }
    private void OnDestroy()
    {
        SceneChanger.CloseScene -= OnObject;
    }
}
