using UnityEngine;
using TMPro;
public class GrowthItemAmountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _growthText;


    private void Start()
    {
        UpdateGrowthText(GameManager.Instance.ItemMax, GameManager.Instance.GrowthItem);
    }



    private void UpdateGrowthText(int maxgrowthamount, int growthamount)
    {
        _growthText.text = $"{ maxgrowthamount} / { growthamount}";
    }
}
