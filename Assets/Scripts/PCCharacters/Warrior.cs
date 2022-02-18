using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Warrior : PlayableCharacter
{

    public Warrior()
    {
        _myStats.LIFE = 50f;
        _myStats.LIFE_CAP = 50f;
        _myStats.DMG = 150f;
        _myStats.SPEED = 5f;
        _myStats.RANGE = 10f;
        _myStats.EXPERIENCE = 0;
        _myStats.EXPERIENCE_CAP = 100;
        _inventory = new InventorySystem();
        _className = "Warrior";

        _abilitySystemReference = new AbilitySystem(_className);
        _levelingSystemReference = new LevelingSystem();
        _passiveAbilities = new PassiveAbility[3];
        _activeAbilities = new ActiveAbility[3];
    }

    public override void SpecialAbility(int p_abilityIndex)
    {
        base.SpecialAbility(p_abilityIndex);
    }
}
