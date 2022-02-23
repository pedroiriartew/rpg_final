using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyActor : EnemyActor
{
    private void Awake()
    {
        _character = new TankEnemy();
    }

    public void SetCharacter(TankEnemy p_character)
    {
        _character = p_character;
    }
}
