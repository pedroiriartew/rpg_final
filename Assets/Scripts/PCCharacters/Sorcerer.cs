using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sorcerer : PlayableCharacter
{
    public Sorcerer()
    {
        _myStats.LIFE = 75;
        _myStats.LIFE_CAP = 75;
        _myStats.DMG = 100;
        _myStats.SPEED = 5f;
        _myStats.RANGE = 15f;
        _myStats.EXPERIENCE = 0;
        _myStats.EXPERIENCE_CAP = 10;
        _inventory = new InventorySystem();
        _className = "Sorcerer";

        _abilitySystemReference = new AbilitySystem(_className);
        _levelingSystemReference = new LevelingSystem();
        _passiveAbilities = new PassiveAbility[3];
        _activeAbilities = new ActiveAbility[3];
    }

    public override void SpecialAbility(int abilityIndex)
    {
        base.SpecialAbility(abilityIndex);
    }
}
