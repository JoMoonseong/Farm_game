using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Unity.Collections.LowLevel.Unsafe;

public class Select : MonoBehaviour
{

    public GameObject creat;
    public Text[] slotText;
    public Text newPlayername;

    bool[] savefile = new bool [3];

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name;

            }
            else
            {
                slotText[i].text = "비어있음";
            }
        }
        DataManager.instance.DataClear();
    }


    void Update()
    {
        
    }

    public void slot_txt(int number)
    {
        DataManager.instance.nowSlot = number;

        if (savefile[number])
        {
            DataManager.instance.LoadData();
            LoadGame();
        }
        else
        {
            make();
        }

    }
    public void make()
    {
        creat.gameObject.SetActive(true);
    }

    public void LoadGame()
    {
        if (!savefile[DataManager.instance.nowSlot])
        {
            DataManager.instance.nowPlayer.name = newPlayername.text;
            DataManager.instance.SaveData();
        } 
        SceneManager.LoadScene(2);
    }
}
