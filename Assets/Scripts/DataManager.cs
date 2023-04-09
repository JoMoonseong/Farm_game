using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    public string name;
    public int coin;
    public int item;
}



public class DataManager : MonoBehaviour
{

    public static DataManager instance;

   public PlayerData nowPlayer = new PlayerData();

    public string path;
    public int nowSlot;
    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(instance.gameObject);

        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
        path = Application.persistentDataPath + " /Save1 "; //������ ������ ��
    }
    void Start()
    {

        
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path +nowSlot.ToString(), data);
        
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
         nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}