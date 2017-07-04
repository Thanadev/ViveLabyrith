using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayButtonController : MonoBehaviour {

    private GameController gameC;

    void Awake()
    {
        gameC = FindObjectOfType<GameController>();
    }

    public void TriggeredHandler ()
    {
        gameC.LaunchGame();
    }
}
