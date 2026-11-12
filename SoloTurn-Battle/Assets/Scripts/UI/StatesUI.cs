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
        UpdateStates(
            GameManager.Instance.PlayerStates.CurrentHp, 
            GameManager.Instance.PlayerStates.CurrentMp,
            GameManager.Instance.PlayerStates.Attack,
            GameManager.Instance.PlayerStates.Defense,
            GameManager.Instance.PlayerStates.Speed);
    }
    private void UpdateStates( float currenthp, int currentmp, float attack, float defend, int speed )
    {
        if(_hPText != null)
        {
            _hPText.text = $"{currenthp}/500";
        }
        if (_mPText != null)
        {
            _mPText.text = $"{currentmp}/500";
        }
        if (_attackText != null)
        {
            _attackText.text = $"{attack}/500";
        }
        if (_defendText != null)
        {
            _defendText.text = $"{defend}/500";
        }
        if (_speedText != null)
        {
            _speedText.text = $"{speed}/500";
        }
    }
}
