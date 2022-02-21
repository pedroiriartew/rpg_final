using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPrefab : MonoBehaviour
{
    [SerializeField] private string _dialoguePath;
    [SerializeField] private string _name;

    private FriendlyCharacter _npcScript;
    private bool _hasBeenTalkedTo = false;
    private int _lineIndex = 0;

    private void Start()
    {
       _npcScript = new FriendlyCharacter();
       _npcScript.SetDialogueSystem(FileLoaderDialogues.GetInstance().LoadDialogueData(_dialoguePath).GetDialogueSystem()); ;
    }

    public void Interact()
    {
        if (!_hasBeenTalkedTo)
        {
            if (_lineIndex >= _npcScript.GetDialogueSystem().GetLinesLength())
            {
                _hasBeenTalkedTo = true;
                _lineIndex = 0;
                _npcScript.GetDialogueSystem().dialogueIndex++;
            }
            else
            {
                DialogueUI.GetInstance().Dialogue(_npcScript.GetDialogueSystem().ActionDialogue(_lineIndex));
                _lineIndex++;
            }

        }
        else if (_hasBeenTalkedTo)
        {
            DialogueUI.GetInstance().Dialogue(_npcScript.GetDialogueSystem().ActionDialogue(_lineIndex));
        }
    }
}
