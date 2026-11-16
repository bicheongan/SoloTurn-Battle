using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClearCountAdd : MonoBehaviour
{
    [SerializeField] private Button _endButton;
    public void CountAdd() 
    {
        GameManager.Instance.AddCount();
        _endButton.interactable = false;
    }
}
