using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text timer1; //����
    public Text timer2; // �Ҽ��ڸ�
    public Text text2; // ���� ���
  
    void Update()
    {
        if(GameLauncher.gameState == GameLauncher.GameState.GameOver)
        {
            text2.text = "GameOver";
        }
        else
        {
            float printFloat = GameLauncher.limitTimer;

            string text = string.Format("{0 : 0.00}", printFloat);

            string[] str = text.Split(".");

            string editedString = str[0] + ".";

            timer1.text = editedString;
            timer2.text = str[1];

            
        }
    }
}
