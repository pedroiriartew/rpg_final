using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCharacter : BaseCharacter
{
    protected static int _enemyCount = 0;
    


}

public class TankEnemy : EnemyCharacter
{
    public TankEnemy()
    {

        _myStats.LIFE = 100;
        _myStats.DMG = 75;
        _myStats.SPEED = 2f;
        _myStats.RANGE = 25f;

        //Los comento porque despu�s me fijo con m�s atenci�n que poner en cada uno

        _enemyCount++;
    }
}


public class FastEnemy : EnemyCharacter
{
    public FastEnemy()
    {

        _myStats.LIFE = 100;
        _myStats.DMG = 75;
        _myStats.SPEED = 2f;
        _myStats.RANGE = 25f;

        //Los comento porque despu�s me fijo con m�s atenci�n que poner en cada uno
        _enemyCount++;
    }
}

public class NormalEnemy : EnemyCharacter
{
    public NormalEnemy()
    {

        _myStats.LIFE = 100;
        _myStats.DMG = 75;
        _myStats.SPEED = 2f;
        _myStats.RANGE = 25f;

        //Los comento porque despu�s me fijo con m�s atenci�n que poner en cada uno
        _enemyCount++;
    }

}
