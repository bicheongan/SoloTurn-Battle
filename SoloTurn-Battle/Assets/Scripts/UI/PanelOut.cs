using UnityEngine;

public class PanelOut : MonoBehaviour
{
    [SerializeField] private GameObject _panel;


    public void OutButton()
    {
        _panel.SetActive(false);
    }
}
