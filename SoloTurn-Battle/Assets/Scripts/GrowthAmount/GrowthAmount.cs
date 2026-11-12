using UnityEngine;

public class GrowthAmount : MonoBehaviour
{
    [SerializeField] private int _itemAmount;

    public void ItmeCall()
    {
        GrowthItemdata.itemamount = _itemAmount;
    }
}
