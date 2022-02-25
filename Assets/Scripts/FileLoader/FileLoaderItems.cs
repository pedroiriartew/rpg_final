using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoaderItems
{
    private static FileLoaderItems _instance;

    private string _path = "items";

    private ItemCollection _itemsData = null;

    public static FileLoaderItems GetInstance()
    {
        if (_instance == null)
        {
            _instance = new FileLoaderItems();
        }

        return _instance;
    }

    public ItemCollection LoadItemsCollection()
    {
        TextAsset info = Resources.Load<TextAsset>(_path);
        string jsonLoadItemData = info.text;
        _itemsData = JsonUtility.FromJson<ItemCollection>(jsonLoadItemData);

        return _itemsData;
    }

}
