using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven_manager : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;

    [HideInInspector]
    public Image image;


    public PlayerController player;

    public Slot slot;

    public GameObject show_info;

    public int infoss = 0;

    public void Use(ItemProperty item)
    {
        this.item = item;


    }


    public void Info()
    {
        show_info.SetActive(true);
        infoss++;

        if (infoss == 2)
        {
            show_info.SetActive(false);
            infoss = 0;
        }
    }



}
