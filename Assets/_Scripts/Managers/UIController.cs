using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private TextMeshProUGUI _currentTurnAgentName;

    private Transform AbilitiesParent;
    private GameObject AbilityButtonTemplate;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        AbilitiesParent = GameObject.Find("AbilitiesParent").transform;
        AbilityButtonTemplate = GameObject.Find("Template_AbilityButton");
    }

    ///Public
    //Set up UI of the new current turn agent
    public void SetCurrentTurnAgent(Agent agent)
    {
        _currentTurnAgentName.text = agent.Name;
    }

    public void SetupAbilityInterface(Agent agent)
    {
        ClearAbilitiesParent();
        CreateAbilitiesButtons(agent);
    }

    ///Setup ability UI
    private void CreateAbilitiesButtons(Agent agent)
    {
        foreach(var ability in agent.Abilities)
        {
            GameObject abilityButton = Instantiate(AbilityButtonTemplate);
            Button button = abilityButton.GetComponent<Button>();
            Text buttonText = abilityButton.transform.GetChild(0).GetComponent<Text>();

            abilityButton.transform.SetParent(AbilitiesParent);
            button.onClick.AddListener(() => InputController.instance.SelectAbility(ability));
            buttonText.text = ability.Name;

            abilityButton.transform.localScale = Vector3.one;
        }
    }

    private void ClearAbilitiesParent()
    {
        foreach(Transform child in AbilitiesParent)
        {
            if (child.gameObject != AbilityButtonTemplate)
                Destroy(child.gameObject);
        }
    }
}
