using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        EnemyFactory.GetInstance().RequestEnemy(Random.Range(1, 4), _spawnPoint.position);
    }
}
