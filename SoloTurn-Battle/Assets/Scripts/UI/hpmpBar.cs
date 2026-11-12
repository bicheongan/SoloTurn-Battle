using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class hpmpBar : MonoBehaviour
{
    [Header("Hp,Mp UI 연결~")]
    [SerializeField] private TMP_Text _hPText;
    [SerializeField]private Image _hPBar;
    [SerializeField] private TMP_Text _mPText;
    [SerializeField] private Image _mPBar;


    private void Start()
    {
        UpdateHpMpBar(
            GameManager.Instance.PlayerStates.MaxHp,
            GameManager.Instance.PlayerStates.CurrentHp,
            GameManager.Instance.PlayerStates.MaxMp,
            GameManager.Instance.PlayerStates.CurrentMp);
    }


    private void UpdateHpMpBar(float maxhp, float currenthp, int maxmp, int currentmp)
    {
        _hPText.text = $"{maxhp}/{currenthp}";
        _hPBar.fillAmount = currenthp / maxhp;
        _mPText.text = $"{maxmp}/{currentmp}";
        _mPBar.fillAmount = currentmp / maxmp;
    }
}
