using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    public UserInput UserInput;

    private GameObject _hoverPointer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UserInput = new UserInput();
    }

    public void SelectAbility(AbilityData ability)
    {
        UserInput.SelectAbility(ability);
    }

    public void SelectTarget(Agent agent)
    {
        UserInput.SelectTarget(agent);
    }

    public void TargetHoverEnter(GameObject obj)
    {
        if (UserInput.PlayerInputState != PlayerInputState.SelectTarget)
            return;

        if (_hoverPointer == null) _hoverPointer = Instantiate(PrefabManager.instance.HoverPointerPrefab);

        _hoverPointer.SetActive(true);
        _hoverPointer.transform.SetParent(obj.transform);
        _hoverPointer.transform.localPosition = new Vector3(0, 0.2f, 0);
    }

    public void TargetHoverExit()
    {
        if (_hoverPointer != null)
        {
            _hoverPointer.SetActive(false);
        }
    }
}
