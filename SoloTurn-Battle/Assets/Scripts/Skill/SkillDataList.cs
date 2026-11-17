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

    public bool HasNotSkillCheck(SkillData skilllsit)// 스킬 중복 검사 메서드
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
    public bool SettingInSkill(SkillData skill)
    {
        if (HasNotSkillCheck(skill) == true) // 배웠는지 검사
        {
            Debug.Log("배우지 못한 스킬");
            return false;
        }
        if (CanSetSkill(skill) == false) return false; // 장착되어 있는지 검사
        for(int i = 0; i< _equipSkill.Length; i++)
        {
            if(_equipSkill[i] == null)
            {
                _equipSkill[i] = skill;
                return true;
            }
        }

        Debug.Log("칸 가득 참");
        return false;
    }
    public void SettingOutSkill(SkillData skill)
    {
        for (int i = 0; i < _equipSkill.Length; i++)
        {
            if (_equipSkill[i] == skill)
            {
                _equipSkill[i] = null;
                Debug.Log("스킬 빼기 성공");
            }
            else
            {
                Debug.Log("칸에 존재하지 않는 스킬이다");
            }
        }

    }

    public bool CanSetSkill(SkillData skill)
    {
        for (int i = 0; i < _equipSkill.Length; i++)
        {
            if (_equipSkill[i] == skill)
            {
                return false;
            }
        }
        return true;
    }
}
