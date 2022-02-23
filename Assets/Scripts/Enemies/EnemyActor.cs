using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActor : MonoBehaviour
{
    protected EnemyCharacter _character;
    protected PlayerActor _actor;
    private void Start()
    {
        _actor = PlayerSingleton.GetInstance().GetPlayer();
    }

    public void ReceiveDamage(float dmg)
    {
        _character.ReceiveDmg(dmg);
        if (_character.GetLife() <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        ItemGenerator.GetInstance().CreateItem(transform.position);
        Destroy(gameObject);
    }

    private void Update()
    { 
        transform.position = Vector3.MoveTowards(transform.position, _actor.transform.position, _character.GetSpeed() * Time.deltaTime);
    }
}
