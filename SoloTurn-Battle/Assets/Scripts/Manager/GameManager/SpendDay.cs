using UnityEngine;

public class SpendDay : MonoBehaviour
{
    [SerializeField] private int _speedDay =1;

    public void usingDay()
    {
        GameManager.Instance.UseTime(_speedDay);
        GameManager.Instance.DateCheck();
    }
}
