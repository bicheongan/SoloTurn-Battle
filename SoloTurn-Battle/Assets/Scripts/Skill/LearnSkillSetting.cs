using System;
using UnityEngine;
using UnityEngine.UI;

public class LearnSkillSetting : MonoBehaviour
{
    [SerializeField] private SkillData _skill;
    [SerializeField] private Button _button;
    [SerializeField] private GrowthItemAmountUI _ui;
    public void LearnSkill()
    {
        if (GameManager.Instance.CanLearnSkills(_skill) == true)
        {
            _button.interactable = false;
            _ui.UpdateGrowthText();
        }
    }
}
