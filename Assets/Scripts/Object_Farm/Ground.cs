using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static Ground instance;
    public GameObject other2;

    Rigidbody rig;

    public bool Dug = false;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hoe")
        {
            Debug.Log("¶¥À»ÆÍ´Ù!");
            Vector2 velocity = transform.GetComponent<Rigidbody>().velocity;
            Vector3 position = transform.position;
            Destroy(gameObject);
            GameObject g = Instantiate(other2);
            g.transform.position = position;
            g.GetComponent<Rigidbody>().velocity = velocity;
            SoundManager.instance.audlist[4].Play();
        }



    }


}
