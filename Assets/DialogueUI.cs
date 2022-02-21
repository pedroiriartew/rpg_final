using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _UI;
    private bool _dialogueBoxTimer = false;
    private float _dialogueDelay = 10f;
    #region Singleton
    private static DialogueUI _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static DialogueUI GetInstance()
    {
        return _instance;
    }
    #endregion

    public void Dialogue(string p_dialogue)
    {
        _UI.SetActive(true);
        _text.text = p_dialogue;
        _dialogueBoxTimer = true;
    }

    public void Update()
    {
        if (_dialogueBoxTimer)
        {
            _dialogueDelay -= Time.deltaTime;

            if (_dialogueDelay <=0)
            {
                _UI.SetActive(false);
                _dialogueBoxTimer = false;
                _text.text = "";
                _dialogueDelay = 10f;
            }
        }
    }
}
