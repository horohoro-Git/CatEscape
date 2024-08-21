using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class GameLauncher : MonoBehaviour
{
    public PlayerController pc;
    static public Action onGameOverAction;
    public static float limitTimer = 30f;
    public Text ResultText;
    public InputManager inputManager;
    public enum GameState
    {
        Playing,
        SpeedUp,
        GameOver
    }
    public static GameState gameState;
    void Start()
    {
        onGameOverAction = () => { GameOver(); };
        inputManager.onMove = (dir) => { pc.PlayerMove(dir); };
    }

    void Update()
    {
        if (gameState != GameState.GameOver)
        {
            ScoreManager.score += Time.deltaTime / 0.001f * 0.01f;
            limitTimer -= Time.deltaTime;

            if (limitTimer < 15f)
            {
                gameState = GameState.SpeedUp;
                ArrowGenerator.maxElapsedTime = 0.25f;
            }

            if (limitTimer < 0f)
            {
                limitTimer = 0f;
                gameState = GameState.GameOver;
                GameLauncher.onGameOverAction();
            }
        }
     
    }
    public void GameOver()
    {

        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");

        ScoreManager.score += arrows.Length * 10;

        for(int i=0; i < arrows.Length; i++)
        {
            Destroy(arrows[i].gameObject);
        }
        Destroy(pc.gameObject);

        ResultText.text = string.Format("{0 : 0,000Á¡}", ScoreManager.score * 100f); //$"{(int)leastTime * 10}";
    }
}
