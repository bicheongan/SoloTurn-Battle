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
            _hPText.text = $"500 /{ currenthp}";
        }
        if (_mPText != null)
        {
            _mPText.text = $"500 /{currentmp}";
        }
        if (_attackText != null)
        {
            _attackText.text = $"500 /{attack}";
        }
        if (_defendText != null)
        {
            _defendText.text = $"500 /{defend}";
        }
        if (_speedText != null)
        {
            _speedText.text = $"500 /{speed}";
        }
    }
}
