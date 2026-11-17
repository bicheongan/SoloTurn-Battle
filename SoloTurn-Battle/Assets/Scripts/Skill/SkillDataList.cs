using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public void SettingInSkill(int num, int skillnum)
    {
        if (num < 0 || _equipSkill.Length <= num)
        {
            Debug.Log("장착칸 범위를 넘었습니다.");
            return;
        }
        if(skillnum <0 || _skillList.Count <= skillnum)
        {
            Debug.Log("습득 스킬 목록 범위 초과");
            return;
        }
        for(int i = 0; i < _equipSkill.Length; i++)
        {
            if (_equipSkill[i] == _skillList[skillnum])
            {
                Debug.Log("중복 장착불가");
                return;
            }
        }
        _equipSkill[num] = _skillList[skillnum];
    }
    public void SettingOutSkill(int num)
    {
        if (num < 0 || _equipSkill.Length <= num)
        {
            Debug.Log("범위를 넘었습니다.");
            return;
        }
        _equipSkill[num] = null;

    }
}
