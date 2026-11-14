using UnityEngine;
using TMPro;
public class UpStateText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField]private EnumText _enumText;

    private void Start()
    {
        UpText();
    }
    public void UpText()
    {
        if (_enumText == EnumText.HpOk)
        {
            _text.text = $"{GameManager.Instance.PlayerStates.MaxHp} (+{GameManager.Instance.PlayerStates.TrainingMaxHp})";
        }
        if(_enumText == EnumText.MpOk)
        {
            _text.text = $"{GameManager.Instance.PlayerStates.MaxMp} (+{GameManager.Instance.PlayerStates.TrainingMaxMp})";
        }
        if(_enumText == EnumText.AttackOk)
        {
            _text.text = $"{GameManager.Instance.PlayerStates.Attack} (+{GameManager.Instance.PlayerStates.TrainingAttack})";
        }
        if(_enumText == EnumText.DefendOk)
        {
            _text.text = $"{GameManager.Instance.PlayerStates.Defense} (+{GameManager.Instance.PlayerStates.TrainingDefend})";
        }
        if(_enumText == EnumText.SpeedOk)
        {
            _text.text = $"{GameManager.Instance.PlayerStates.Speed} (+{GameManager.Instance.PlayerStates.TrainingSpeed})";
        }
    }
}
