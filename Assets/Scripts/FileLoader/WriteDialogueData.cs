using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteDialogueData : MonoBehaviour
{
    private void Awake()
    {
        string json = JsonUtility.ToJson(new PassiveAbility());

        File.WriteAllText(Application.dataPath + "/JSON_Files/PassiveAbility.json", json);
    }
}
