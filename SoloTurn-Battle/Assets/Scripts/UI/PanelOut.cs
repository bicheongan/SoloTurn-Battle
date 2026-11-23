using UnityEngine;

public class PanelOut : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Start()
    {
        if (GameManager.Instance._isLookPlan == true)
        {
            _panel.SetActive(false);
        }
    }
    public void OutButton()
    {
        _panel.SetActive(false);
    }
    public void OutCheckButton()
    {
        _panel.SetActive(false);
        GameManager.Instance._isLookPlan = true;
    }
}
