using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSetting : MonoBehaviour
{
    [SerializeField]private SkillData _skill;
    [SerializeField] private GameObject _set; 
    [SerializeField] private GameObject _out; 

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
            }
        }
        else
        {
            GameManager.Instance.SkillDataList.SettingOutSkill(_skill);
            _set.SetActive(true);
            _out.SetActive(false);
        }
    }
}
