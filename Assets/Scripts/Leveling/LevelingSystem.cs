using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingSystem
{
    private int _currentLevel;
    private int _abilityPoints;//Cambiar valor inicial

    //CREAR UN COSNTRUCTOR-->Asegurarse que esto se cree en el rogue, en el warrior y en el Sorcerer

    public LevelingSystem()
    {
        _currentLevel = 1;
        _abilityPoints = 2;
    }

    public void LevelUp()
    {
        _currentLevel++;
        _abilityPoints++;
    }

    //Spend Points, CheckPoints

    public void SpendAbilityPoints(int amountToSpend)
    {
        _abilityPoints -= amountToSpend;
    }

    public bool CanAbilityPointsBeSpent(int amountToSpend)
    {
        if (amountToSpend > _abilityPoints)
        {
            return false;
        }

        return true;
    }

    public int GetAbilityPoints()
    {
        return _abilityPoints;
    }

    public int GetLevel()
    {
        return _currentLevel;
    }

    //Experiencia para leveleo. Los enemigos dan, las Quest También.

    // Cap de leveleo.

    //La experiencia se multiplica por una constante de 1.5x para tardar más a niveles mayores.

    //Cuando gano la experiencia, me fijo si supera al cap, si supera, lo resto para quedarme con el resto y luego multiplico el cap por la constante.
}
