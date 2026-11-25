using UnityEngine;

public class SettingText : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _text1;

    public void OpenText()
    {
        if (GameManager.Instance._stageEnum == StageEnum.Dungeon)
        {
            _text.SetActive(true);
        }
        if (GameManager.Instance._stageEnum == StageEnum.Battle || GameManager.Instance._stageEnum == StageEnum.Boss)
        {
            _text1.SetActive(true);
        }
    }
}
