using UnityEngine.UI;
using UnityEngine;

public class PurchasableAbilitySlot : ShopAbilitySlot
{
    public void BuyAbilityFromListUI()
    {
        if(AbilityHUD.GetInstance().AddToAvailableAbilityList(this))
            Destroy(gameObject);
    }
}
