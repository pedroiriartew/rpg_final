using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyArray;

    #region Singleton
    private static EnemyFactory _instance = null;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static EnemyFactory GetInstance()
    {
        return _instance;
    }

#endregion

    public GameObject RequestEnemy(int p_enemy)
    {

        GameObject goMesh;

        switch (p_enemy)
        {
            case 1:
                goMesh = Instantiate(_enemyArray[0], Vector3.zero, Quaternion.identity);
                goMesh.AddComponent<NormalEnemyActor>();
                goMesh.GetComponent<NormalEnemyActor>().SetCharacter(new NormalEnemy());
                break;
            case 2:
                goMesh = Instantiate(_enemyArray[1], Vector3.zero, Quaternion.identity);
                goMesh.AddComponent<FastEnemyActor>();
                goMesh.GetComponent<FastEnemyActor>().SetCharacter(new FastEnemy());
                break;
            case 3:
                goMesh = Instantiate(_enemyArray[2], Vector3.zero, Quaternion.identity);
                goMesh.AddComponent<TankEnemyActor>();
                goMesh.GetComponent<TankEnemyActor>().SetCharacter(new TankEnemy());
                break;
            default:
                goMesh = null;
                break;
        }

        return goMesh;
    }

    public GameObject RequestEnemy(int p_enemy, Vector3 p_position)
    {

        GameObject goMesh;

        switch (p_enemy)
        {
            case 1:
                goMesh = Instantiate(_enemyArray[0], p_position, Quaternion.identity);
                goMesh.AddComponent<NormalEnemyActor>();
                goMesh.GetComponent<NormalEnemyActor>().SetCharacter(new NormalEnemy());
                break;
            case 2:
                goMesh = Instantiate(_enemyArray[1], p_position, Quaternion.identity);
                goMesh.AddComponent<FastEnemyActor>();
                goMesh.GetComponent<FastEnemyActor>().SetCharacter(new FastEnemy());
                break;
            case 3:
                goMesh = Instantiate(_enemyArray[2], p_position, Quaternion.identity);
                goMesh.AddComponent<TankEnemyActor>();
                goMesh.GetComponent<TankEnemyActor>().SetCharacter(new TankEnemy());
                break;
            default:
                goMesh = null;
                break;
        }

        return goMesh;
    }
}
