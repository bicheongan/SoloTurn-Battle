using System;
using UnityEngine;

public class HpMpRest : MonoBehaviour
{
    public void Recovery()
    {
        GameManager.Instance.PlayerStates.CurrentHp = GameManager.Instance.PlayerStates.MaxHp;
        GameManager.Instance.PlayerStates.CurrentMp = GameManager.Instance.PlayerStates.MaxMp;
    }
    public void StageRecovery()
    {
        float HpHeal = GameManager.Instance.PlayerStates.MaxHp * 0.3f;
        int MpHeal = (int)(GameManager.Instance.PlayerStates.MaxMp * 0.3f);
        GameManager.Instance.PlayerStates.CurrentHp = Mathf.Min(GameManager.Instance.PlayerStates.MaxHp, GameManager.Instance.PlayerStates.CurrentHp + HpHeal);
        GameManager.Instance.PlayerStates.CurrentMp = Mathf.Min(GameManager.Instance.PlayerStates.MaxMp, GameManager.Instance.PlayerStates.CurrentMp + MpHeal);
    }
}
