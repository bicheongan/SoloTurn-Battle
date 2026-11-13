using UnityEngine;
using TMPro;
public class GrowthItemAmountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _growthText;


    private void Start()
    {
        UpdateGrowthText();
    }



    public void UpdateGrowthText()
    {
        _growthText.text = $"{GameManager.Instance.GrowthItem} / {GameManager.Instance.ItemMax}";
    }
}
