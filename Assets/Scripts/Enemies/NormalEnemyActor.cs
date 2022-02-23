using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyActor : EnemyActor
{
    private void Awake()
    {
        _character = new NormalEnemy();
    }

    public void SetCharacter(NormalEnemy p_character)
    {
        _character = p_character;
    }
}
