using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    bool maxGrow = false;
    public float set = 0;
    float maxSetValue = 5.0f;

    public GameObject First;
    public GameObject Second;
    public GameObject Third;

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
            
            Second.SetActive(true);
            
        }
        if (set > 3.0f)
        {
            Second.SetActive(false);
            Third.SetActive(true);
            Area.enabled = true;
        }
    }



}
