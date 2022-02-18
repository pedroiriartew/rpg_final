using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHUD : MonoBehaviour
{
    [SerializeField] private Text _level;
    [SerializeField] private Text _abilityPoints;

    // Start is called before the first frame update

    private void Awake()
    {
        PlayerSingleton.GetInstance().GetPlayer().levelUp += UpdateUI;
    }

    public void UpdateUI(int p_level, int p_points )
    {
        _level.text = p_level.ToString();
        _abilityPoints.text = p_points.ToString();
    }


}
