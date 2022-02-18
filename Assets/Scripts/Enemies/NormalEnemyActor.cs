using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyActor : MonoBehaviour
{
    private NormalEnemy _character;
    
    public void SetCharacter(NormalEnemy p_character)
    {
        _character = p_character;
    }

    public NormalEnemy GetCharacter()
    {
        return _character;
    }

    public void Talk()
    {
        Debug.Log("estoy hablando");
    }
}
