using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class PlayerActor : MonoBehaviour
{
    [SerializeField] private PlayableCharacter _character = null;
    //[SerializeField] private float _jumpForce = 0.1f;
    private CharacterController _cc;
    private Animator _animator;

    private float _horizontalMovement = 0f;
    private float _verticalMovement = 0f;

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

    private void Awake()
    {
        PlayerSingleton.GetInstance().SetPlayer(this);

        _animator = GetComponentInChildren<Animator>();

        _cc = GetComponent<CharacterController>();

        SetCharacter();
    }

    private void Start()
    {
        levelUp?.Invoke(_character.GetLevelingSystem().GetLevel(), _character.GetLevelingSystem().GetAbilityPoints());
    }

    public void GetInput()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        AnimatorInputs();

        if (Input.GetMouseButtonDown(0) )//Left click para atacar
        {
            _animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.E))//Righ click para interactuar con las cosas
        {
            Interact();
        }

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

    private void AnimatorInputs()
    {
        if (_horizontalMovement != 0 || _verticalMovement != 0)
        {
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }

    public void MovePlayer()
    {
        if (_cc.isGrounded)
        {
            _verticalSpeed = 0;
        }
        else
        {
            _verticalSpeed -=_gravity * Time.deltaTime; 
        }

        Vector3 move = transform.forward * _verticalMovement + transform.right * _horizontalMovement;
        Vector3 gravityMove = new Vector3(0, _verticalSpeed, 0);


        _cc.Move(move * Time.deltaTime * _character.GetSpeed() + gravityMove * Time.deltaTime);
    }

    internal void SetTemporaryItemVariables(bool _setTemporaryActive, BaseCharacter.Stats _temporaryItemStats)
    {
        _isTemporaryItemActive = _setTemporaryActive;
        this._temporaryItemStats = _temporaryItemStats;
    }

    /// <summary>
    /// Hace falta reescribir el interactuar
    /// </summary>
    public void Interact()
    {
        //if (Physics.Raycast(ray, out hit, 100))//Un cierto rango para interactuar con las cosas
        //{
        //    Interactable interactable = hit.collider.GetComponent<Interactable>();//es interactuable lo que acabo de clickear?

        //    if (interactable != null)
        //    {
        //        interactable.Interact();
        //    }
        //}
    }
    /// <summary>
    /// Set character lee la data del Json y luego setea los stats y el inventario en este character
    /// </summary>
    public void SetCharacter()
    {
        string json = File.ReadAllText(Application.dataPath + "/JSON_Files/characterFile.json");


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
        MovePlayer();
    }

}
