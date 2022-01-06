using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private TextMeshProUGUI _currentTurnAgentName;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    ///Public
    //Set up UI of the new current turn agent
    public void SetCurrentTurnAgent(Agent agent)
    {
        _currentTurnAgentName.text = agent.Name;
    }
}
