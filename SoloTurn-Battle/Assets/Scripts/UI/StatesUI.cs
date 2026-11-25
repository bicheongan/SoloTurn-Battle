using UnityEngine;
using TMPro;
public class StatesUI : MonoBehaviour
{
    [Header("스탯UI")]
    [SerializeField] private TMP_Text _hPText;
    [SerializeField] private TMP_Text _mPText;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _defendText;
    [SerializeField] private TMP_Text _speedText;


    private void Start()
    {
        UpdateStates();
    }
    public void UpdateStates()
    {
        if(_hPText != null)
        {
            _hPText.text = $"{GameManager.Instance.PlayerStates.MaxHp}/" +
                $"{GameManager.Instance.PlayerStates.MaxTrainingHp}";
        }
        if (_mPText != null)
        {
            _mPText.text = $"{GameManager.Instance.PlayerStates.MaxMp}/" +
                $"{GameManager.Instance.PlayerStates.MaxTrainingMp}";
        }
        if (_attackText != null)
        {
            _attackText.text = $"{GameManager.Instance.PlayerStates.Attack}/" +
                $"{GameManager.Instance.PlayerStates.MaxTrainingAttack}";
        }
        if (_defendText != null)
        {
            _defendText.text = $"{GameManager.Instance.PlayerStates.Defense}/" +
                $"{GameManager.Instance.PlayerStates.MaxTrainingDefend}";
        }
        if (_speedText != null)
        {
            _speedText.text = $"{GameManager.Instance.PlayerStates.Speed}/" +
                $"{GameManager.Instance.PlayerStates.MaxTrainingSpeed}";
        }
    }
}
