using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Takeit : MonoBehaviour
{
    public BoxCollider box;

    [SerializeField]
    PlayerController Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (box.enabled == true)
        {
            if(other.tag == "Weat")
            {
                Destroy(GameObject.Find("WeatSeed(Clone)"));
                Player.Weat++;
                Player.Changeimage();  
                if (Player.Weat <= 4)
                {
                    Player.Seed1Check = false;
                }
            }

            if (other.tag == "Carrot")
            {
                Destroy(GameObject.Find("CarrotSeed(Clone)"));
                Player.Carrot++;
                if (Player.Carrot <= 4)
                {
                    Player.Seed2Check = false;
                }
            }

            if (other.tag == "Corn")
            {
                Destroy(GameObject.Find("CornSeed(Clone)"));
                Player.Corn++;
                if (Player.Corn <= 4)
                {
                    Player.Seed3Check = false;
                }
            }
  
        }
    }



}
