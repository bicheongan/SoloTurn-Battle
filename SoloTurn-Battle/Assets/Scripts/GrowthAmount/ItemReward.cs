using UnityEngine;

public class ItemReward : MonoBehaviour
{
    [SerializeField]private int reward;

    public void RewardAmount()
    {
        reward = GrowthItemdata.itemamount;
        Debug.Log(reward);
        GameManager.Instance.ItemAdd();
    }
    public void RetryAmount()
    {
        reward += GrowthItemdata.itemamount;
        Debug.Log(reward);
    }

}
