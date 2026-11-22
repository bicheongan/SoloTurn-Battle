using UnityEngine;

public class SpendDay2 : MonoBehaviour
{
    [SerializeField] private int _DnnguneSpeedDay =1;
    [SerializeField] private int _StageSpeedDay =3;

    public void usingDay()
    {
        if (GameManager.Instance._stageEnum == StageEnum.Dungeon)
        {
            GameManager.Instance.UseTime(_DnnguneSpeedDay);
            GameManager.Instance.DateCheck();
        }
        if (GameManager.Instance._stageEnum == StageEnum.Battle)
        {
            GameManager.Instance.UseTime(_StageSpeedDay);
            GameManager.Instance.DateCheck();
        }
        if (GameManager.Instance._stageEnum == StageEnum.Boss)
        {
            GameManager.Instance.UseTime(_StageSpeedDay);
            GameManager.Instance.DateCheck();
        }
    }
}
