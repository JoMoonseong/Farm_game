using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Animal : MonoBehaviour
{
    Animator ani;
    SoundManager smg;
    Rigidbody rig;


    [SerializeField]
    private string AnimalName;

    [SerializeField]
    private float WalkSpeed;

    [SerializeField]
    private float walkTime;
    [SerializeField]
    private float waitTime;

    private Vector3 dir;
    private float currentTime;

    bool isAction;
    bool isWalking;

    void Start()
    {
        ani = GetComponent<Animator>();
        smg = GetComponent<SoundManager>();
        rig = GetComponent<Rigidbody>();

        currentTime = waitTime;
        isAction = true;
    }

   
    void Update()  
    {
        move();
        Rotation();
        ElapseTime();

    }


    void move()
    {
        if (isWalking)
        {
            rig.MovePosition(transform.position + transform.forward * WalkSpeed * Time.deltaTime);
            
        }
    }
    void Rotation()
    {
        if(isWalking)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, dir, 0.01f);
            rig.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    void ElapseTime()
    {
        if (isAction)
        {
            
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                Reset_1();
        }


    }

     void Reset_1()
    {
        isWalking = false;
        isAction = true;
        ani.SetBool("isWalk", isWalking);

        dir.Set(0f, Random.Range(0f, 360f), 0f);

        RandomAction(); 
    }


    void RandomAction()
    {
        int _random = Random.Range(0, 4);

        if (_random == 0)
            Wait();
        else if (_random == 1)
            TryWalk();
    } 


    void Wait()
    {
        currentTime = waitTime;
        
    }


    void TryWalk()
    {
        currentTime = walkTime;
        isWalking = true;
        ani.SetBool("isWalk", isWalking);
        
    }


    public void OnMouseDown()
    {
        if (tag == "Pig")
        {
            Debug.Log("오잉크!");
            ani.SetTrigger("doOink");
            SoundManager.instance.audlist[0].Play();
        }
        else if (tag == "Chick")
        {
            Debug.Log("삐약!");
            ani.SetTrigger("doJJack");
            SoundManager.instance.audlist[2].Play();
        }
        else if (tag == "Chicken")
        {
            Debug.Log("꼬끼오");
            ani.SetTrigger("doGgo");
            SoundManager.instance.audlist[1].Play();
        }

    } 
}
