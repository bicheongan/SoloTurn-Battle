using System.Security.Cryptography;
using UnityEngine;

public class EnterPanel : MonoBehaviour
{
    [SerializeField]private GameObject _enterPanel;

    public void EnterPanels()
    {
        _enterPanel.SetActive(true);
    }
}
