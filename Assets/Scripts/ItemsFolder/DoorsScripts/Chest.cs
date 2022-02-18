using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool _wasUsed = false;
    [SerializeField] Transform _spawnPoint;

    public void DropItem()
    {
        if (!_wasUsed)
        {
            ItemGenerator.GetInstance().CreateItem(_spawnPoint.position);
            _wasUsed = true;
        }
    }

}
