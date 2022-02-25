using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class PlayerActor : MonoBehaviour
{
    [SerializeField] private PlayableCharacter _character = null;

    public event Action OpenCloseInventory;
    public event Action OpenCloseAbilities;
    public event Action OpenCloseQuests;

    public delegate void LevelUp(int lvl, int points);
    public LevelUp levelUp;

    private const float DEFAULT_TEMPORARY_VALUE = 10.0f;
    private float _temporaryItemTimer = DEFAULT_TEMPORARY_VALUE;
    private bool _isTemporaryItemActive = false;
    private BaseCharacter.Stats _temporaryItemStats;

    private float _gravity = 9.8f;
    private float _verticalSpeed = 0f;

    private Animator _animator;

    private void Awake()
    {
        PlayerSingleton.GetInstance().SetPlayer(this);
        _animator = GetComponent<Animator>();

        SetCharacter();

    }

    private void Start()
    {
        levelUp?.Invoke(_character.GetLevelingSystem().GetLevel(), _character.GetLevelingSystem().GetAbilityPoints());
    }

    public void GetInput()
    {

        //Abro el inventario
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseInventory?.Invoke();
        }

        //Abro el menu de habilidades para comprar y equipar
        if (Input.GetKeyDown(KeyCode.K))
        {
            OpenCloseAbilities?.Invoke();
        }

        //Abro el menu para ver las habilidades
        if (Input.GetKeyDown(KeyCode.J))
        {
            OpenCloseQuests?.Invoke();
        }

    }

    internal void SetTemporaryItemVariables(bool _setTemporaryActive, BaseCharacter.Stats _temporaryItemStats)
    {
        _isTemporaryItemActive = _setTemporaryActive;
        this._temporaryItemStats = _temporaryItemStats;
    }


    /// <summary>
    /// Set character lee la data del Json y luego setea los stats y el inventario en este character
    /// </summary>
    public void SetCharacter()
    {
        TextAsset info = Resources.Load<TextAsset>("characterFile");

        string json = info.text;


        CharacterData characterData = JsonUtility.FromJson<CharacterData>(json);


        if (characterData.GetDataCharacterClass() == "Rogue")
        {
            _character = new Rogue();
            _character.SetNewStats(characterData.GetDataStats());
            _character.SetInventory(characterData.GetDataInventory());
            _character.SetAbilitySystemReference(characterData.GetAbilitySystem());
        }

        if (characterData.GetDataCharacterClass() == "Sorcerer")
        {
            _character = new Sorcerer();
            _character.SetNewStats(characterData.GetDataStats());
            _character.SetInventory(characterData.GetDataInventory());
            _character.SetAbilitySystemReference(characterData.GetAbilitySystem());
        }

        if (characterData.GetDataCharacterClass() == "Warrior")
        {
            _character = new Warrior();
            _character.SetNewStats(characterData.GetDataStats());
            _character.SetInventory(characterData.GetDataInventory());
            _character.SetAbilitySystemReference(characterData.GetAbilitySystem());
        }
    }

    public PlayableCharacter GetCharacter()
    {
        return _character;
    }

    /// <summary>
    /// Se fija si el item temporal acabo su efecto
    /// </summary>
    private void CheckTemporaryItem()
    {
        _temporaryItemTimer -= Time.deltaTime;

        Debug.Log(_temporaryItemTimer);

        if (_temporaryItemTimer <= 0)
        {
            _isTemporaryItemActive = false;
            _temporaryItemTimer = DEFAULT_TEMPORARY_VALUE;
            _character.SetLessStats(_temporaryItemStats);
        }
    }

    public void CheckLevelUp(float p_experience)
    {
        if(_character.CheckLevelUp(p_experience))
            levelUp?.Invoke(_character.GetLevelingSystem().GetLevel(), _character.GetLevelingSystem().GetAbilityPoints());
    }
    private void Update()
    {
        if (_isTemporaryItemActive)
        {
            CheckTemporaryItem();
        }

        GetInput();
    }

}
