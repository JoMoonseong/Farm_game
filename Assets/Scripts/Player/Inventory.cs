using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    public Transform rootSlot;

    private List<Slot> slots;

    public Store store;

    public PlayerController player;



    void Start()
    {
        slots = new List<Slot>();

        int SlotCnt = rootSlot.childCount;
        for (int i = 0; i < SlotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }

        store.onSlotClick += BuyItme;
        
    }




    void BuyItme(ItemProperty item)
    {
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;


        });

        if (emptySlot != null)
        {
            emptySlot.SetItem(item);
            player.nowGold -= 100;
        }


    }


}
