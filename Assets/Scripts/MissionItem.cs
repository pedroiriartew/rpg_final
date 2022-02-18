using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MissionItem : MonoBehaviour
{

    [SerializeField] private MiscellaneousItem _missionItem = null;
    // Start is called before the first frame update
    private void Awake()
    {
        Initialize();
    }

    public void Interact()
    {
        FindObjectOfType<NPCDummy>().SetHasSkull(true);
        _missionItem = null;
        Destroy(gameObject);
    }


    private void Initialize()
    {
        _missionItem = FileLoaderItems.GetInstance().LoadItemsCollection().GetMiscellaneousItemList()[2];
        _missionItem.SetIcon(Resources.Load<Sprite>(_missionItem.GetResourcesDataPath()));
        gameObject.GetComponent<SpriteRenderer>().sprite = _missionItem.GetIcon();
    }
}
