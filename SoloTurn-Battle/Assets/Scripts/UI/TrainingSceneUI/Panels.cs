using UnityEngine;
using System.Collections.Generic;

public class Panels : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private List<GameObject> _panels;

    public void OpenPanel()
    {
        _panel.SetActive(true);
    }
    public void ClosePanel()
    {
        for (int i = 0; i < _panels.Count; i++)
        {
            _panels[i].SetActive(false);
        }
    }
}
