using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager instance;

    public GameObject AgentObjectPrefab;
    public GameObject HoverPointerPrefab;
    public GameObject AttackReadyIndicatorPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
}
