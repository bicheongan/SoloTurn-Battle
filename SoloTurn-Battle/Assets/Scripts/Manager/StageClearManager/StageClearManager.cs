using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
public class StageClearManager : MonoBehaviour
{
    [SerializeField]private List<GameObject> _StageButton;
    [SerializeField]private List<GameObject> _StageClear;
    [SerializeField]private List<Button> _button;

    private void Start()
    {
        Clearcheck();
    }
    private void Clearcheck()
    {
        if(GameManager.Instance.ClearCount <4)
        {
            for (int i = 1; i < _button.Count; i++)
            {
                _button[i].interactable = false;
            }
        }
        if (GameManager.Instance.ClearCount == 0)
        {
            _button[0].interactable = true;
        }
        if (GameManager.Instance.ClearCount == 1)
        {
            _button[0].interactable = false;
            _button[1].interactable = true;
        }
        if (GameManager.Instance.ClearCount == 2)
        {
            _button[0].interactable = false;
            _button[1].interactable = false;
            _button[2].interactable = true;
        }
        if (GameManager.Instance.ClearCount == 3)
        {
            _button[0].interactable = false;
            _button[1].interactable = false;
            _button[2].interactable = false;
            _button[3].interactable = true;
        }

    }
}
