using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteDialogueData : MonoBehaviour
{
    private void Awake()
    {
        string json = JsonUtility.ToJson(new DialogueData());

        File.WriteAllText(Application.dataPath + "/JSON_Files/Dialogue-Ryan.json", json);
    }
}
