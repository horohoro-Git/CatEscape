using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float radius = 1f;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // Debug.Log("AA");

            transform.Translate(-1, 0, 0);
            float clamp = Mathf.Clamp(transform.position.x, -8, 8);
            transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
            float clamp = Mathf.Clamp(transform.position.x, -8, 8);
            transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
          //  Debug.Log("BB");
        }
    }

    private void OnDrawGizmos()
    {
        GizmoExtentions.DrawWireArc(transform.position, 360, radius);
    }
}
