using System;
using Unity.VisualScripting;
using UnityEngine;

public class GrowState : MonoBehaviour
{
    [SerializeField]private EnumStates _state;
    [SerializeField] private IsMax _isMaxState;
    [SerializeField]private StatesUI _statesUI;
    [SerializeField]private GrowthItemAmountUI _growthItemAmountUI;
    public void grow()
    {
        GameManager.Instance.PlayerStates.ChangeIsMax(_isMaxState);
        if (GameManager.Instance.PlayerStates.IsCanNot() == true) return; 
        if(GameManager.Instance.TrainingSucess() == true )
        {
            GameManager.Instance.PlayerStates.ChangeEnumState(_state);
            GameManager.Instance.PlayerStates.TrainngState();
            Debug.Log("강화성공");
            _statesUI.UpdateStates();
            _growthItemAmountUI.UpdateGrowthText();
        }
    }
}
