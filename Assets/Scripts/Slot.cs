using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;


    public Image image;
    public Button sellBtn;

    
    public PlayerController player;


    public Store store;


    public GameObject Panel;

    

    private void Awake()
    {
        SetsellBtn(false);
    }


    void SetsellBtn(bool b)
    {
        if (sellBtn != null)
        {
            sellBtn.interactable = b;
        }
    }


    public void SetItem(ItemProperty item)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;
            SetsellBtn(false);
            gameObject.name = "Empty";
        }

        else if (item != null)
        {
            image.enabled = true;
            gameObject.name = item.name;
            image.sprite = item.sprite;
            SetsellBtn(true);
            
        }
        
    }

    public void OnClickSellBtn()
    {
        SetItem(null);
        player.nowGold += 100;
        if (store.WheatAct == true)
        {
            store.WheatAct = false;

            if (store.WheatAct == false)
            {
                player.Weat_Seed = false;
            }
        }
        if (store.CarrotAct == true)
        {
            store.CarrotAct = false;

            if (store.CarrotAct == false)
            {
                player.Carrot_Seed = false;
            }
        }
        if (store.CornAct == true)
        {
            store.CornAct = false;

            if (store.CornAct == false)
            {
                player.Corn_Seed = false;
            }
        }
    }

    public void UseItem()
    {
        if (item.name == "WheatSeed")
        {
            SetItem(null);
            player.Weat_Seed = true;
            Panel.SetActive(false);
        }
        else if (item.name == "CarrotSeed")
        {
            SetItem(null);
            player.Carrot_Seed = true;
            Panel.SetActive(false);
        }
        else if (item.name == "CornSeed")
        {
            SetItem(null);
            player.Corn_Seed = true;
            Panel.SetActive(false);
        }



    }
}
