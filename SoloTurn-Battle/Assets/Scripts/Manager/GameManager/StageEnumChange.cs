using Unity.VisualScripting;
using UnityEngine;

public class StageEnumChange : MonoBehaviour
{
    [SerializeField] private StageEnum stageEnum;
    public void ChangeStageEnum()
    {
        GameManager.Instance._stageEnum = stageEnum;
    }
    public void ChangeReset()
    {
        GameManager.Instance._stageEnum = StageEnum.None;
    }
}
