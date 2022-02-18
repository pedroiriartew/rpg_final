using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilitySystem
{
    [SerializeField] private List<AbilityNode> _abilitiesToBuy = null;
    [SerializeField] private List<AbilityNode> _availableAbilities = null;
    [SerializeField] private AbilityData _classAbilities = null;
    [SerializeField] private string _className;

    public AbilitySystem(string _className)
    {
        _abilitiesToBuy = new List<AbilityNode>();
        _availableAbilities = new List<AbilityNode>();

        this._className = _className;

        LoadClassAbilitiesFromJson();

        AddStarterAbilities();
    }

    public void LoadClassAbilitiesFromJson()
    {
        switch (_className)
        {
            case "Warrior":
                _classAbilities = FileLoaderAbilities.GetInstance().LoadAbilityData(Application.dataPath + "/JSON_Files/WarriorAbilityList.json");
                break;

            case "Sorcerer":
                _classAbilities = FileLoaderAbilities.GetInstance().LoadAbilityData(Application.dataPath + "/JSON_Files/SorcererAbilityList.json");
                break;

            case "Rogue":
                _classAbilities = FileLoaderAbilities.GetInstance().LoadAbilityData(Application.dataPath + "/JSON_Files/RogueAbilityList.json");
                break;

            default:
                Debug.Log("Oh no what have you done");
                break;
        }
    }

    public void AddStarterAbilities()//Esto debe estar muy mal hecho pero realmente tendr�a que sentarme a solucionarlo y pensarlo con un tiempo que no tengo asi que anyway
    {
        PassiveAbility[] passiveAbilities = _classAbilities.GetPassiveAbilities();
        ActiveAbility[] activeAbilities = _classAbilities.GetActiveAbilities();

        foreach (PassiveAbility passiveAbility in passiveAbilities)
        {
            if (passiveAbility.GetPointsToBuy() == 1)
            {
                AddAbilityToBuy(passiveAbility);
            }
        }

        foreach (ActiveAbility activeAbility in activeAbilities)
        {
            if (activeAbility.GetPointsToBuy() == 1)
            {
                AddAbilityToBuy(activeAbility);
            }
        }
    }

    public bool BuyAbility(int abilityID, LevelingSystem levelingSystem)
    {
        foreach (AbilityNode ability in _abilitiesToBuy)
        {
            if (abilityID == ability.GetAbilityID() && !ability.GetComprado())
            {
                if (!levelingSystem.CanAbilityPointsBeSpent(ability.GetPointsToBuy()))
                {
                    //Return false, no puedo comprar esta habilidad
                    return false;
                }

                //Puedo comprar la habilidad

                levelingSystem.SpendAbilityPoints(ability.GetPointsToBuy());

                ability.SetComprado(true);//�sta habilidad figura como comprada a partir de ahora.

                //Agrego los nodos de habilidad que puedo comprar con el array que reci�n compre
                AbilityNode[] newAvailableNodes = ability.GetAbilityNodesArray();

                foreach (AbilityNode item in newAvailableNodes)
                {
                    AddAbilityToBuy(item);
                }

                //Agrego la habilidad a la lista de habilidades disponibles y la quito de poder comprarse

                AddAbilityToAvailable(ability);

                RemoveAbilityFromBuyList(ability);

                return true;
            }
        }
        //Esta habilidad no se encuentra para comprar o fue comprada (lo cual no deber�a pasar).
        return false;
    }

    private bool AddAbilityToBuy(AbilityNode newAbility)
    {
        foreach (AbilityNode item in _abilitiesToBuy)
        {
            if (item.GetAbilityID() == newAbility.GetAbilityID())
            {
                return false;
            }
        }
        _abilitiesToBuy.Add(newAbility);
        return true;
    }

    private bool AddAbilityToAvailable(AbilityNode newAbility)
    {
        foreach (AbilityNode item in _availableAbilities)
        {
            if (item.GetAbilityID() == newAbility.GetAbilityID())
            {
                return false;
            }
        }
        _availableAbilities.Add(newAbility);
        return true;
    }

    private bool RemoveAbilityFromBuyList(AbilityNode newAbility)
    {
        foreach (AbilityNode item in _abilitiesToBuy)
        {
            if (item.GetAbilityID() == newAbility.GetAbilityID())
            {
                _abilitiesToBuy.Remove(item);
                return true;
            }
        }

        return false;
    }

    public AbilityNode GetAbilityFromAvailableAbilities(int _id)//Esto es llamado por el PC que luego castea a la habilidad que necesita
    {
        foreach (AbilityNode item in _availableAbilities)
        {
            if (item.GetAbilityID() == _id)
            {
                return item;
            }
        }
        //No deber�a retornar nulo
        return null;
    }

    public AbilityData GetClassAbilities()
    {
        return _classAbilities;
    }

    public List<AbilityNode> GetPurchasableAbilities()
    {
        return _abilitiesToBuy;
    }

    public List<AbilityNode> GetAvailableAbilities()
    {
        return _availableAbilities;
    }
}
