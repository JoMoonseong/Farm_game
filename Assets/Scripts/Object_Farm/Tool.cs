using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public enum Type {Hoe, Fork};
    public Type type;
    public BoxCollider Tool_Area;
    
    void Start()
    {
        GetComponent<BoxCollider>();
    }


    public void Tool_detect()
    {
        
        StartCoroutine("Area_Active");
    }


    IEnumerator Area_Active()
    {
        yield return new WaitForSeconds(0.5f);
        Tool_Area.enabled = true;

        yield return new WaitForSeconds(1f);
        Tool_Area.enabled = false;

    }


}
