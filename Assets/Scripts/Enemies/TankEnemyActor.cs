using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyActor : MonoBehaviour
{
    private TankEnemy _character;

    public void SetCharacter(TankEnemy p_character)
    {
        _character = p_character;
    }
}
