using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//������
// �����͸� Json���� ��ȯ
class Data
{
    public string SaveName;
    public int Gold;
}




public class Save : MonoBehaviour
{

    PlayerController player;

    Data SaveGold = new Data() { SaveName = "���̽�Ž���", Gold = 1000};

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