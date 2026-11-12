using UnityEngine;

public class LoseOutHp1 : MonoBehaviour
{
    public void Lose()
    {
        GameManager.Instance.PlayerStates.CurrentHp = 1;
        Debug.Log(GameManager.Instance.PlayerStates.CurrentHp);
    }
}
