using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkillSetting : MonoBehaviour
{
    [SerializeField]private SkillData _skill;
    [SerializeField]private List<SkillSlotUI> _skillSlots;
    [SerializeField] private GameObject _set; 
    [SerializeField] private GameObject _out;

    private void OnEnable()
    {
        if (GameManager.Instance.SkillDataList.CanSetSkill(_skill) == true)
        {
            _set.SetActive(true);
            _out.SetActive(false);
        }
        else
        {
            _set.SetActive(false);
            _out.SetActive(true);
        }
        UIIconCheck();
    }

    public void SkillSetOut()
    {
        // 스킬 칸 확인
        if (GameManager.Instance.SkillDataList.CanSetSkill(_skill) == true)
        {
            //스킬 장착
            if (GameManager.Instance.SkillDataList.SettingInSkill(_skill) == true)
            {
                _set.SetActive(false);
                _out.SetActive(true);
                UIIconCheck();
            }
        }
        else
        {
            GameManager.Instance.SkillDataList.SettingOutSkill(_skill);
            _set.SetActive(true);
            _out.SetActive(false);
            UIIconCheck();
        }
    }
    private void UIIconCheck()
    {
        foreach (var slot in _skillSlots)
        {
            slot.UpdateIcon();
        }
    }
}
