using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPrefab : MonoBehaviour
{
    [SerializeField] private string _dialoguePath;
    [SerializeField] private int[] _IDs;
    [SerializeField] private string _name;

    private FriendlyCharacter _npcScript;
    private bool _hasBeenTalkedTo = false;
    private int _lineIndex = 0;

    private void Start()
    {
       _npcScript = new FriendlyCharacter();
       _npcScript.SetDialogueSystem(FileLoaderDialogues.GetInstance().LoadDialogueData(_dialoguePath).GetDialogueSystem()); ;
    }

    public void Interact()//La peor versión de un código que he hecho
    {
        //if (!QuestManagerSystem.GetInstance().IsQuestActive(_IDs[0]) && !QuestManagerSystem.GetInstance().IsQuestFinished(_IDs[0]))
        //{
        //    QuestManagerSystem.GetInstance().AddQuest(_IDs[0]);
        //}

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
                Debug.Log(_npcScript.GetDialogueSystem().ActionDialogue(_lineIndex));
                _lineIndex++;
            }

        }
        else if (_hasBeenTalkedTo)
        {
            Debug.Log(_npcScript.GetDialogueSystem().ActionDialogue(_lineIndex));
        }

        //GetComponentInChildren<Text>().text = _dialogueSystem.ActionDialogue(_IDs[2]);
    }


    public int[] GetIDs()
    {
        return _IDs;
    }

    public void SetIDs(int quest, int stage, int objective)
    {
        _IDs[0] = quest;
        _IDs[1] = stage;
        _IDs[2] = objective;
    }
}
