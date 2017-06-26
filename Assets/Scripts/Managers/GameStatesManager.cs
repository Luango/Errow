using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesManager : MonoBehaviour {
    public static bool isGaming;
    private void Awake()
    {
        isGaming = true;
    }

    private void Update()
    {
        if(Input.GetKey("q") || Input.GetKey("e"))
        {
            isGaming = false;
            Time.timeScale = 0.1f;
            print("q or e key down");
            // Show switch arrow or secondary weapon bar.

        }
        else
        {
            isGaming = true;
            Time.timeScale = 1f;
            print("q key up");
        }
    }

    static public void ChangeGameStates()
    {
        isGaming = !isGaming;
        if (isGaming)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    // Show weapon selection.

}
