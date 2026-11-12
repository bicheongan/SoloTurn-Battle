using UnityEngine;

public class ItemReward : MonoBehaviour
{
    public void RewardAmount()
    {
        GameManager.Instance.ItemAdd();
        GrowthItemdata.itemamount = 0;
    }
    public void RetryAmount()
    {
        GameManager.Instance.ItemAdd();
    }

}
