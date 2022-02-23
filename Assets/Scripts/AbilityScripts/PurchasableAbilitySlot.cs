using UnityEngine.UI;
using UnityEngine;

public class PurchasableAbilitySlot : ShopAbilitySlot
{
    public void BuyAbilityFromListUI()
    {
        Debug.Log("Purchased ability");
        AbilityHUD.GetInstance().AddToAvailableAbilityList(this);
    }
}
