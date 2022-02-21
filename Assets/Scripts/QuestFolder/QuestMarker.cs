using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarker : MonoBehaviour
{
    [SerializeField] private int _questID;
    [SerializeField] private int _stageID;
    [SerializeField] private int _objectiveID;
    private bool _interacted = false;

    public void Interact()
    {
        if (QuestManagerSystem.GetInstance().IsQuestActive(_questID))
        {

            if (QuestManagerSystem.GetInstance().ReturnCurrentObjectiveID(_questID) == _objectiveID)
            {
                QuestManagerSystem.GetInstance().MarkObjective(_questID, _stageID, _objectiveID);
            }
        }
    }
}
