using UnityEngine;

public class RestPanel : MonoBehaviour
{
    [SerializeField] private GameObject _restPanel;

    public void OpenRestPanel()
    {
        _restPanel.SetActive(true);
    }
    public void CloseRestPanel()
    {
        _restPanel.SetActive(false);
    }
}
