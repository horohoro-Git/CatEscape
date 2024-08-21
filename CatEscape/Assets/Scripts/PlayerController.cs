using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public struct PlayerData
{
   public int hp { get; set; }

    public void DataSetup(int hp)
    {
        this.hp = hp;
    }
}



public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public enum Direction
    {
        Right,
        Left
    }


    private void Start()
    {
        playerData.DataSetup(100);
    }

    public float radius = 1f;
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        GizmoExtentions.DrawWireArc(transform.position, 360, radius);
    }

    public void AttackedByArrow(ArrowController arrowController)
    {
        playerData.hp -= arrowController.damage;
        if (playerData.hp < 0)
        {
            playerData.hp = 0;
            GameLauncher.gameState = GameLauncher.GameState.GameOver;
            GameLauncher.onGameOverAction();
        }

        GameObject canv = GameObject.Find("HPGauge(front)");

        
        Image im = canv.GetComponent<Image>();

        
        im.fillAmount = (float)playerData.hp / 100f;
    }

    public void PlayerMove(Direction direction)
    {
        if(direction == Direction.Left)
        {
            transform.Translate(-1, 0, 0);
        }
        else if(direction == Direction.Right)
        {
            transform.Translate(1, 0, 0);
        }        
        float clamp = Mathf.Clamp(transform.position.x, -8, 8);
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
    }
}
