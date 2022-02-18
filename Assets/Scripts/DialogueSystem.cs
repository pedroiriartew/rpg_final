using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSystem
{
    [SerializeField] private Dialogue[] _dialogue;

    public int dialogueIndex = 0;

    public string ActionDialogue(int lineIndex)//QuestID como par�metro y el segundo la l�nea.
    {
        return _dialogue[dialogueIndex].ReturnLine(lineIndex);
    }

    public int GetLinesLength()
    {
        return _dialogue[dialogueIndex].GetLength();
    }
}
