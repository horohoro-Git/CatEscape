using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    public Button btnL;
    public Button btnR;
    // Start is called before the first frame update
    void Start()
    {
        btnR.onClick.AddListener(RightButtonClick);
        btnL.onClick.AddListener(LeftButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButtonClick()
    {
        Debug.Log("���� ��ư Ŭ��");



    }
    public void RightButtonClick()
    {
        Debug.Log("������ ��ư Ŭ��");

        transform.Translate(1, 0, 0);

    }
}
