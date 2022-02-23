using UnityEngine;
using UnityEngine.UI;

public class AvailableAbilitySlot : ShopAbilitySlot
{
    public void AddAbilityToArrayFromListUI()
    {
        Debug.Log("Added ability");
        AbilityHUD.GetInstance().AddAbilityToPlayerArray(this);
    }
}
