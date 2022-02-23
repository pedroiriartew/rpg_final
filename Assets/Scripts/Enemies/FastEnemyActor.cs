using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyActor : EnemyActor
{
    private void Awake()
    {
        _character = new FastEnemy();
    }


    public void SetCharacter(FastEnemy p_character)
    {
        _character = p_character;
    }
}
