using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//데이터
// 데이터를 Json으로 변환
class Data
{
    public string SaveName;
    public int Gold;
}




public class Save : MonoBehaviour
{

    PlayerController player;

    Data SaveGold = new Data() { SaveName = "제이슨탐험기", Gold = 1000};

    void Start()
    {
       

        string jsonData =  JsonUtility.ToJson(SaveGold);

        Data Player2 = JsonUtility.FromJson<Data>(jsonData);
        print(Player2.SaveName);
        print(Player2.Gold);
    } 


    void Update()
    {
        
    }
}
