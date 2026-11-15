using UnityEngine;
using TMPro;
public class DateUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _dateText;

    private void Start()
    {
        DateText();
    }
    private void DateText()
    {
        _dateText.text = $"{GameManager.Instance.RemainDay}/{GameManager.Instance.TotalDate}";
    }
}
