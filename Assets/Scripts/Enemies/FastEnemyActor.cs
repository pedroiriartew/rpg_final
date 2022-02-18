using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyActor : MonoBehaviour
{
    private FastEnemy _character;

    public void SetCharacter(FastEnemy p_character)
    {
        _character = p_character;
    }
}
