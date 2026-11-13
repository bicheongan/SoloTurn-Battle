using UnityEngine;
using TMPro;
public class HpText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        UpHpText();
    }
    public void UpHpText()
    {
        _text.text = $"{GameManager.Instance.PlayerStates.MaxHp} (+{GameManager.Instance.PlayerStates.TrainingMaxHp})";
    }
}
