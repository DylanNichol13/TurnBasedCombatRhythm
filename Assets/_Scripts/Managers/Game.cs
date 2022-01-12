using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        BattleController.instance.Initialize();
        UIController.instance.Initialize();
        RhythmController.instance.Initialize();
        InputController.instance.Initialize();
    }

    //Game events
}
