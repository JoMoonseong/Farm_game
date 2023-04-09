using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    bool maxGrow = false;
    public float set = 0;
    float maxSetValue = 5.0f;

    public GameObject Test0;
    public GameObject Test1;
    public GameObject Test2;

    public BoxCollider Area;
    void Start()
    {

        Area.enabled = false;
    }

    
    void Update()
    {
        Plus();
        show();
    }




    void Plus()
    {
        if (maxGrow == false)
        {
            set += 0.01f;
            Debug.Log("ÇÃ·¯½º");
            if (set >= maxSetValue)
            {
                maxGrow = true;
            }

        }
    }

    void show()
    {
        if (set > 2.0f)
        {
            
            Test1.SetActive(true);
            
        }
        if (set > 3.0f)
        {
            Test1.SetActive(false);
            Test2.SetActive(true);
            Area.enabled = true;
        }
    }



}
