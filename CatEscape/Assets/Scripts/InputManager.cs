using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<PlayerController.Direction> onMove;
   
    void Update()
    {
        if (GameLauncher.gameState != GameLauncher.GameState.GameOver)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onMove(PlayerController.Direction.Left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                onMove(PlayerController.Direction.Right);
            }
        }
    }
}
