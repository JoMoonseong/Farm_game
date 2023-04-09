using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public static Spring instance;

    public float speed;

    public GameObject Spin;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Spining()
    {
        Spin.transform.Rotate(Vector3.up * Time.deltaTime * 200);
        Debug.Log("돌아간다");

    }

}
