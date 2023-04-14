using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public itemBuffer itemBuffer;
    public Transform slotRoot;
    public PlayerController players;
    private List<Slot> slots;

    public System.Action<ItemProperty> onSlotClick;

    public bool WheatAct = false;
    public bool CarrotAct = false;
    public bool CornAct = false;


    void Start()
    {
        slots = new List<Slot>();

        int slotCnt = slotRoot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }
            else
            {
                slot.GetComponent<Button>().interactable = false;
            }
            slots.Add(slot);
        }
    }

    



    public void OnClickSlot(Slot slot)
    {
        if (onSlotClick != null)
        {
            onSlotClick(slot.item);
        }
        if (slot.item.name == "WheatSeed")
        {
            WheatAct = true;
            if (players.Weat_Seed)
            {
                Debug.Log("심을수있음");

            }
        }

        if (slot.item.name == "CarrotSeed")
        {
            CarrotAct = true;
            if (players.Carrot_Seed)
            {
                Debug.Log("심을수있음");
            }
        }

        if (slot.item.name == "CornSeed")
        {
            
            CornAct = true;
            if (players.Corn_Seed)
            {
                Debug.Log("심을수있음");
            }
        }
    }
}  
