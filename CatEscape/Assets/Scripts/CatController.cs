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
        Debug.Log("왼쪽 버튼 클릭");



    }
    public void RightButtonClick()
    {
        Debug.Log("오른쪽 버튼 클릭");

        transform.Translate(1, 0, 0);

    }
}
