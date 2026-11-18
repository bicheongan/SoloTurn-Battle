using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LearnSkillSetting : MonoBehaviour
{
    [SerializeField] private SkillData _skill;
    [SerializeField] private Button _button;
    [SerializeField] private GrowthItemAmountUI _ui;
    [SerializeField] private GameObject _equipButton;
    [SerializeField] private GameObject _skillUI;
    [SerializeField] private GameObject _getPanel;
    [SerializeField] private GameObject _failLearnUI;

    private void Start()
    {
        if(GameManager.Instance.SkillDataList.HasNotSkillCheck(_skill) == false)
        {
            _button.interactable = false;
            _equipButton.SetActive(true);
        }
    }
    public void LearnSkill()
    {
        if (GameManager.Instance.CanLearnSkills(_skill) == true)
        {
            _equipButton.SetActive(true);
            _getPanel.SetActive(true);
            _skillUI.SetActive(false);
            _button.interactable = false;
            _ui.UpdateGrowthText();
        }
        else if (GameManager.Instance.CanLearnSkills(_skill) == false)
        {
            StartCoroutine(panel());
        }
    }

    private IEnumerator panel()
    {
        _failLearnUI.SetActive(true);
        yield return new WaitForSeconds(2);
        _failLearnUI.SetActive(false);
    }
}
