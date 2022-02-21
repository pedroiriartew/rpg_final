using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private int _questID;
     
    private bool _interacted = false;
    public void Interact()
    {
        if (!_interacted)
        {
            if (!QuestManagerSystem.GetInstance().IsQuestActive(_questID))
            {
                QuestManagerSystem.GetInstance().AddQuest(_questID);
                _interacted = true;
            }
        }
    }
}
