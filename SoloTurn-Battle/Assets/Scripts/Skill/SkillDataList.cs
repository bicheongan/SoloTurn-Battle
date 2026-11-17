using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class SkillDataList
{
    [Header("배운스킬 리스트")]
    [SerializeField] private List<SkillData> _skillList;

    [Header("스킬 슬롯")]
    [SerializeField] private SkillData[] _equipSkill;

    public IReadOnlyList<SkillData> SkillList => _skillList;
    public IReadOnlyList<SkillData> EquipSkill => _equipSkill;

    public bool HasSkillCheck(SkillData skilllsit)// 스킬 중복 검사 메서드
    {
        bool result;
        if (!_skillList.Contains(skilllsit))
        {
                result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }
    public void AddSkill(SkillData skill) 
    {
        _skillList.Add(skill);
    }
    public void SettingSkill(int num, int skillnum)
    {
        _equipSkill[num] = _skillList[skillnum];
    }
}
