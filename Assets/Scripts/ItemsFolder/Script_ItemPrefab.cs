using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ItemPrefab : MonoBehaviour
{
    private BaseItem _baseItem = null;

    public void Interact()
    {
        PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetInventory().AddToInventory(_baseItem);
        Destroy(gameObject);
    }

    public void Initialize(BaseItem item)
    {
        BaseItem auxItem = null;
        _baseItem = item;

        if (_baseItem.GetItemType() == BaseItem.ItemType.Consumable) { auxItem = new ConsumableItem(); }
        if (_baseItem.GetItemType() == BaseItem.ItemType.Temporary) { auxItem = new TemporaryItem(); }
        if (_baseItem.GetItemType() == BaseItem.ItemType.Equipable) { auxItem = new EquipableItem(); }
        if (_baseItem.GetItemType() == BaseItem.ItemType.Miscellaneous) { auxItem = new MiscellaneousItem(); }

        auxItem.SetIcon(item.GetIcon());
        auxItem.SetID(item.GetItemID());
        auxItem.SetItemType(item.GetItemType());
        auxItem.SetName(item.GetName());

        auxItem.SetResourcesDataPath(item.GetResourcesDataPath());
        auxItem.SetStats(item.GetStats());

        _baseItem = auxItem;

        _baseItem.SetIcon(Resources.Load<Sprite>(item.GetResourcesDataPath()));
    }

    public BaseItem GetItem()
    {
        return _baseItem;
    }

    public void SetItem(BaseItem newItem)
    {
        _baseItem = newItem;
    }
}
