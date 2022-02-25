using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoaderDialogues
{
    private DialogueData _dialogueData;

    #region Singleton
    private static FileLoaderDialogues _instance;

    public static FileLoaderDialogues GetInstance()
    {
        if (_instance == null)
            _instance = new FileLoaderDialogues();
        return _instance;
    }
    #endregion

    public DialogueData LoadDialogueData(string p_path)
    {
        TextAsset info = Resources.Load<TextAsset>(p_path);
        string jsonLoadDialogueData = info.text;
        _dialogueData = JsonUtility.FromJson<DialogueData>(jsonLoadDialogueData);

        return _dialogueData;
    }
}

[System.Serializable]
public class DialogueData
{
    [SerializeField] private DialogueSystem _dialogueSystem;

    public DialogueData()
    {
        _dialogueSystem = new DialogueSystem();
    }

    public DialogueSystem GetDialogueSystem()
    {
        return _dialogueSystem;
    }
}

[System.Serializable]
public class DialogueInfo
{
    [SerializeField] private Dialogue _dialogue;

    public DialogueInfo()
    {
        _dialogue = new Dialogue();
    }

    public Dialogue GetDialogueSystem()
    {
        return _dialogue;
    }
}
