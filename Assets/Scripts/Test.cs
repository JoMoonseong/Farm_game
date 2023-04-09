using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;


    public PlayerController player;

    public Slot slot;



    public void Use(ItemProperty item)
    {
        this.item = item;


    }

    public void UseSeed()
    {
        if (player.Seed1Check == true)
        {
            Debug.Log("»Ð");
        }
    }

}
