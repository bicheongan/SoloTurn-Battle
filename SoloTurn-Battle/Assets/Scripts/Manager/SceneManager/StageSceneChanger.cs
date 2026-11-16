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
        SceneManager.LoadScene("BattleScene",LoadSceneMode.Additive);
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
