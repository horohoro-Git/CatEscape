using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject player;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        bool isCollided = CheckCollision();
        if(isCollided)
        {
            Object.Destroy(gameObject);
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
            return true;
        }

        return false;
    }
}
