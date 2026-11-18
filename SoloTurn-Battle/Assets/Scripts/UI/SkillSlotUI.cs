using UnityEngine;
using UnityEngine.UI;

public class SkillSlotUI : MonoBehaviour
{
    [SerializeField] private int _slotNum;
    [SerializeField] private Image _iconImage;

    private void OnEnable()
    {
        UpdateIcon();
    }
    public void UpdateIcon()
    {
        SkillData skillData = GameManager.Instance.SkillDataList.EquipSkill[_slotNum];
        if (skillData != null)
        {
            Debug.Log("있어");
            _iconImage.sprite = skillData.SkillIcon;
            _iconImage.enabled = true;
        }
        else
        {
            Debug.Log("없어");
            _iconImage.enabled = false;
        }
    }
}
