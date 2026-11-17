using UnityEngine;

public class SkillSetting : MonoBehaviour
{
    [SerializeField] private int num1 = 0;
    [SerializeField] private int num2 = 0;

    public void SetSkill()
    {
        GameManager.Instance.SkillDataList.SettingInSkill(num1, num2);
    }
    public void OutSkill()
    {
        // 집에서 할거 조회기능 필요하면, 초기화 메서드 게임매니저에 추가하기위해 재시작시, 장착 조금더 손보기 
        GameManager.Instance.SkillDataList.SettingOutSkill(num1);
    }
}
