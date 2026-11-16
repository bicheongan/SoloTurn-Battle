using UnityEngine;

public class MainSpendDay : MonoBehaviour
{
    [SerializeField] private int _speedDay =1;
    [SerializeField] private DateUI _date;

    public void usingDay()
    {
        GameManager.Instance.UseTime(_speedDay);
        _date.DateText();
        GameManager.Instance.DateCheck();
    }
}
