using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyHpUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private Image _hpBar;
    [SerializeField] private Enemy _enemy;

    private void Awake()
    {
        CacheComponent();
    }

    private void OnHpBar(float hp ,float maxhp)
    {
        _hpText.text = $"{hp}/{maxhp}";
        _hpBar.fillAmount = hp / maxhp;
    }
    private void OnEnable()
    {
        _enemy.OnChangeHp += OnHpBar;
    }
    private void OnDisable()
    {
        _enemy.OnChangeHp -= OnHpBar;
    }
    private void CacheComponent()
    {
        _enemy = GetComponentInParent<Enemy>();
    }
}
