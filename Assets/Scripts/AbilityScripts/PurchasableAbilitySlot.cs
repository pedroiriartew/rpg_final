using UnityEngine.UI;

public class PurchasableAbilitySlot : ShopAbilitySlot
{
    public void BuyAbilityFromListUI()
    {
        AbilityHUD.GetInstance().AddToAvailableAbilityList(this);
    }
}
