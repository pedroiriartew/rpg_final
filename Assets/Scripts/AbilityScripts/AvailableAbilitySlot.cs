using UnityEngine.UI;

public class AvailableAbilitySlot : ShopAbilitySlot
{
    public void AddAbilityToArrayFromListUI()
    {
        AbilityHUD.GetInstance().AddAbilityToPlayerArray(this);
    }
}
