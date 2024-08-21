using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArrowController : MonoBehaviour
{
    public ArrowData arrowData;
    public GameObject player;
    public float radius;
    public int damage;
    private float speed; 
    // Start is called before the first frame update
    void Start()
    {

        if (GameLauncher.gameState == GameLauncher.GameState.SpeedUp)
        {

            damage = Random.Range(ArrowData.minDamage * 2, ArrowData.maxDamage * 2 + 1);
            speed = Random.Range(ArrowData.minSpeed, ArrowData.maxSpeed) * 2f;
        }
        else
        {
            damage = Random.Range(ArrowData.minDamage, ArrowData.maxDamage + 1);
            speed = Random.Range(ArrowData.minSpeed, ArrowData.maxSpeed);
     
        }
        if (damage >= ArrowData.maxDamage)
        {
            SpriteRenderer image = GetComponent<SpriteRenderer>();
            image.color = Color.red;
        }
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameLauncher.gameState != GameLauncher.GameState.GameOver)
        {
            if(GameLauncher.gameState == GameLauncher.GameState.SpeedUp)
            {
                
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            else transform.Translate(0, speed * Time.deltaTime, 0);

            bool isCollided = CheckCollision();
            if (isCollided)
            {
                Object.Destroy(gameObject);
            }
        }
    }


    private void OnDrawGizmos()
    {
        GizmoExtentions.DrawWireArc(transform.position, 360, radius);
    }

    //충돌체크를 한후에 충돌이 되었다면 true를 반환
    private bool CheckCollision()
    {
        if (transform.position.y <= -5.5f)
        {
            return true;
        }

        if (Mathf.Abs(transform.position.y - player.transform.position.y) <= 1.4f &&
            Mathf.Abs(transform.position.x - player.transform.position.x) <= 0.5f)
        {
            player.GetComponent<PlayerController>().AttackedByArrow(this);
            return true;
        }

        return false;
    }
}



public struct ArrowData
{
    public const float minSpeed = -3f;
    public const float maxSpeed = -7f;
    public const int minDamage = 5;
    public const int maxDamage = 10;

   
   
}
