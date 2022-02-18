using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    [SerializeField]
    private string _characterClass;

    [SerializeField]
    private BaseCharacter.Stats _characterStats;

    [SerializeField]
    private InventorySystem _characterInventory;

    [SerializeField]
    private AbilitySystem _abilitySystem;

    [SerializeField] private LevelingSystem _levelingSystem;

    public void SetData(BaseCharacter.Stats p_newStats, InventorySystem p_newInventory, string p_newCharacterClass, AbilitySystem p_abilitySystem, LevelingSystem p_levelingSystem)
    {
        _characterStats = p_newStats;
        _characterInventory = p_newInventory;
        _characterClass = p_newCharacterClass;
        _abilitySystem = p_abilitySystem;
        _levelingSystem = p_levelingSystem;
    }

    public LevelingSystem GetLevelingSystem()
    {
        return _levelingSystem;
    }

    public AbilitySystem GetAbilitySystem()
    {
        return _abilitySystem;
    }

    public BaseCharacter.Stats GetDataStats()
    {
        return _characterStats;
    }

    public InventorySystem GetDataInventory()
    {
        return _characterInventory;
    }

    public string GetDataCharacterClass()
    {
        return _characterClass;
    }
}
