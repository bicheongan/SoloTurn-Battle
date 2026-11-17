using System;
using UnityEngine;
using UnityEngine.UI;

public class LearnSkillSetting : MonoBehaviour
{
    [SerializeField] private SkillData _skill;
    [SerializeField] private Button _button;

    public void LearnSkill()
    {
        if (GameManager.Instance.CanLearnSkills(_skill) == true)
        {
            _button.interactable = false;
        }
    }
}
