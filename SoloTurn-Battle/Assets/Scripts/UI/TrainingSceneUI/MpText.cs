using UnityEngine;
using TMPro;
public class MpText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        UpHpText();
    }
    public void UpHpText()
    {
        _text.text = $"{GameManager.Instance.PlayerStates.MaxMp} (+{GameManager.Instance.PlayerStates.TrainingMaxMp})";
    }
}
