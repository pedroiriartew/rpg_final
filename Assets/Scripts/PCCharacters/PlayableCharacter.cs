using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PlayableCharacter : BaseCharacter
{
    [SerializeField] protected InventorySystem _inventory = null;
    [SerializeField] protected string _className;
    [SerializeField] protected PassiveAbility[] _passiveAbilities;//Abilities que aumentan los stats
    [SerializeField] protected ActiveAbility[] _activeAbilities;//Abilities que se activan con un input
    [SerializeField] protected AbilitySystem _abilitySystemReference;
    [SerializeField] protected LevelingSystem _levelingSystemReference;
    [SerializeField] protected const float experienceMultiplier = 1.5f;


    public virtual void SpecialAbility(int p_abilityIndex)//Abity index o ability ID ? ARREGLAR EN CADA UNO DE LAS CLASES DERIVADAS
    {
        //Acá selecciono mi array de habilidades activas, utilizo el índice y luego activo la habilidad
        //Quizás modificar el cooldown--->Active Ability 
    }

    public bool BuyAbility(int p_id)
    {
        return _abilitySystemReference.BuyAbility(p_id, _levelingSystemReference);//Regresa verdadero si se pudo comprar la habilidad
    }

    public bool AddAbilityFromAvailableList(int p_id)
    {
        AbilityNode newAbility = _abilitySystemReference.GetAbilityFromAvailableAbilities(p_id);
        AbilityData abilityLists = _abilitySystemReference.GetClassAbilities();

        bool wasAbilityAdded = false;

        if (newAbility.GetAbilityType() == AbilityNode.AbilityType.Passive)
        {
            foreach (PassiveAbility item in abilityLists.GetPassiveAbilities())
            {
                if (item.GetAbilityID() == newAbility.GetAbilityID())
                {
                    PassiveAbility passiveAbility = item;//Acá creo que es un poco al pedo agregarla así a otra variable

                    //Llamar al array de passive abilities y agregarla.

                    wasAbilityAdded = AddAbilityToArray(passiveAbility);
                }
            }
        }

        if (newAbility.GetAbilityType() == AbilityNode.AbilityType.SpecialMove)
        {
            foreach (ActiveAbility item in abilityLists.GetActiveAbilities())
            {
                if (item.GetAbilityID() == newAbility.GetAbilityID())
                {
                    ActiveAbility activeAbility = item;//Acá creo que es un poco al pedo agregarla así a otra variable

                    //Llamar al array de active abilities y agregarla.

                    wasAbilityAdded = AddAbilityToArray(activeAbility);
                }
            }
        }

        return wasAbilityAdded;
    }

    //string json;
    //json = System.IO.File.ReadAllText(Application.dataPath + "/PassiveStatsList.json");
    //SimpleJSON.JSONNode passiveAbilitiesData = SimpleJSON.JSON.Parse(json);

    //for (int i = 0; i < passiveAbilitiesData["passiveAbilitiesData"].AsArray.Count; i++)
    //{
    //    if (passiveAbilitiesData["passiveAbilitiesData"].AsArray[i]["passiveID"]== newPassiveAbility.GetAbilityID())
    //    {
    //        BaseCharacter.Stats newStats = passiveAbilitiesData["passiveAbilitiesData"].AsArray[i]["stats"];

    //        newPassiveAbility.SetPassiveStats(newStats);
    //    }
    //}

    //public List<AbilityNode> GetPurchasableAbilitiesList()
    //{
    //    return abilitySystemReference.GetPurchasableAbilitiesList();
    //}

    //public List<AbilityNode> GetAbilitiesAvailable()
    //{
    //    return abilitySystemReference.GetAvailableAbilitiesList();
    //}

    //public int GetActiveAbilityFromIndex(int index)//Este método debería devolverme algo para 
    //{
    //   return 
    //}
    private bool AddAbilityToArray(PassiveAbility _passiveAbility)
    {
        for (int i = 0; i < _passiveAbilities.Length; i++)
        {
            if (_passiveAbilities[i] == _passiveAbility)//Ya tengo agregada esta habilidad a mi array
            {
                return false;
            }
            if (_passiveAbilities[i] == null)//En esa posición no hay nada.
            {
                _passiveAbilities[i] = _passiveAbility;
                return true;
            }
        }
        return false;
    }

    private bool AddAbilityToArray(ActiveAbility _activeAbility)
    {
        for (int i = 0; i < _activeAbilities.Length; i++)
        {
            if (_activeAbilities[i] == _activeAbility)//En esa posición, mi nueva habilidad no es la misma que la que hay ahí.
            {
                return false;
            }
            if (_activeAbilities[i] == null)//En esa posición no hay nada.
            {
                _activeAbilities[i] = _activeAbility;
                return true;
            }
        }
        return false;
    }

    public void AddStatsFromEquipment()
    {
        BaseItem[] equipment = _inventory.GetEquipment();

        for (int i = 0; i < equipment.Length; i++)
        {
            if (equipment[i] != null)
            {
                SetMoreStats(equipment[i].GetStats());
            }
        }
    }


    //No sé si lo voy a usar a esto todavía pero por si las dudas lo tengo creado 
    public void SetMoreStats(Stats moreStats)
    {
        _myStats.DMG += moreStats.DMG;

        _myStats.LIFE += moreStats.LIFE;

        _myStats.LIFE_CAP += moreStats.LIFE_CAP;

        _myStats.RANGE += moreStats.RANGE;

        _myStats.SPEED += moreStats.SPEED;
    }

    public void SetLessStats(Stats lessStats)
    {
        _myStats.DMG -= lessStats.DMG;

        _myStats.LIFE -= lessStats.LIFE;

        _myStats.LIFE_CAP -= lessStats.LIFE_CAP;

        _myStats.RANGE -= lessStats.RANGE;

        _myStats.SPEED -= lessStats.SPEED;
    }

    public void SetNewStats(Stats newStats)
    {
        _myStats = newStats;
    }

    public void SetAbilitySystemReference(AbilitySystem abilitySystem)
    {
        if (abilitySystem == null)
            _abilitySystemReference = abilitySystem;
    }

    public Stats GetStats()
    {
        return _myStats;
    }
    public InventorySystem GetInventory()
    {
        return _inventory;
    }
    public void SetInventory(InventorySystem newInventory)
    {
        _inventory = newInventory;
    }

    public string GetClassName()
    {
        return _className;
    }

    public bool CheckLevelUp(float p_experience)
    {
        _myStats.EXPERIENCE += p_experience;
        if (_myStats.EXPERIENCE >= _myStats.EXPERIENCE_CAP)
        {
            _myStats.EXPERIENCE = 0;
            _myStats.EXPERIENCE_CAP *= 2;
            _levelingSystemReference.LevelUp();

            return true;
        }
        return false;
    }

    public PassiveAbility[] GetPassiveAbilities()
    {
        return _passiveAbilities;
    }

    public ActiveAbility[] GetActiveAbilities()
    {
        return _activeAbilities;
    }

    public List<AbilityNode> GetPurchasableAbilitiesList()
    {
        return _abilitySystemReference.GetPurchasableAbilities();
    }
    public List<AbilityNode> GetAvailableAbilitiesList()
    {
        return _abilitySystemReference.GetAvailableAbilities();
    }

    public AbilitySystem GetAbilitySystemReference()
    {
        return _abilitySystemReference;
    }

    public LevelingSystem GetLevelingSystem()
    {
        return _levelingSystemReference;
    }
}
