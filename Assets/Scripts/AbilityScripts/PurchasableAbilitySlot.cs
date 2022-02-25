using UnityEngine.UI;
using UnityEngine;

public class PurchasableAbilitySlot : ShopAbilitySlot
{
    public void BuyAbilityFromListUI()
    {
        AbilityHUD.GetInstance().AddToAvailableAbilityList(this);
    }
}
