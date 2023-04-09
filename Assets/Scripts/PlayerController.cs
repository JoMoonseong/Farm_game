using System.Collections;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int count = 0;

    public static PlayerController instance;

    public float Speed;
    public VariableJoystick joy;
    public Ground Filed;

    public bool Seed1Check = false;
    public bool Seed2Check = false;
    public bool Seed3Check = false;


    Rigidbody rig;
    CapsuleCollider cap;
    Animator ani;
    Vector3 moveVec;

    Vector3 dirVec;

    Spring spring;

    public BoxCollider Area;

    public BoxCollider Havr_Area;

    //public GameObject Door;

    public GameObject Ground1;

    public GameObject Ground2;

    public ParticleSystem SeedEffect;


    public bool EquitTool = false;

    public bool Harv;
    public bool ItemGet = false;
    public bool Seed_Active = false;

    public bool Scan_Seed = false;
    public Text text;
    public Text Count_Text;
    
    public GameObject Guide;

    public Image image;
    public Image itemimage;
    public Sprite change_item; 
    public GameObject Inventory;
    public GameObject store;
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Wheat_cnt;
    public TextMeshProUGUI Carrot_cnt;
    public TextMeshProUGUI Corn_cnt;
    public Button EquitBtn;



    public int Weat = 0;
    public int Carrot = 0;
    public int Corn = 0;


    public int nowGold = 0;
    public int clickCnt = 0;



    //public GameObject Water;

    [Header("씨앗")]
    public GameObject Seed1;
    public GameObject Seed2;
    public GameObject Seed3;


    [Header("도구")]
    public GameObject Tool;

    [Header("위치1")]
    public Transform Target;
    public Transform Target2;
    public Transform Target3;
    public Transform Target4;


    [Header("씨앗활성화")]
    public bool Weat_Seed = false;
    public bool Carrot_Seed = false;
    public bool Corn_Seed = false;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        cap = GetComponent<CapsuleCollider>();

        //Door.GetComponent<Door>();

        

    }

    void Update()
    {
        move();
        //Cooler(); 
        InfoItem();

        Gold.text = nowGold.ToString();
        Wheat_cnt.text = Weat.ToString();
        Carrot_cnt.text = Carrot.ToString();
        Corn_cnt.text = Corn.ToString();  

        ray();

    }


      void ray()
    {
        RaycastHit hiting;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hiting, 1.5f))
        {
           if (hiting.transform.tag == "Store")
            {
                store.SetActive(true);
                SoundManager.instance.audlist[5].Play();
            }

        }
        else
        {
            store.SetActive(false);
            
        }

    }

    void move()
    {
        float x = joy.Horizontal;
        float z = joy.Vertical;

        moveVec = new Vector3(x, 0, z) * Speed * Time.deltaTime;
        rig.MovePosition(rig.position + moveVec);

        if (moveVec.sqrMagnitude == 0)
        {
            SoundManager.instance.audlist[3].Play();
            ani.SetBool("isRun", false);
            
            return;
        }
        else
        {
            
            ani.SetBool("isRun", true);
        }


        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rig.rotation, dirQuat, 0.3f);
        rig.MoveRotation(moveQuat);
    }


    public void Dig_A()
    {
        ani.SetTrigger("doDigA");
        
    }

    public void Seed()
    {
        ani.SetTrigger("doSeed");
        SeedEffect.Play();
        Seed_Active = true;

        if (!Seed1Check && Weat_Seed)
        {
            Instan_Seed1();
        }
        if (!Seed2Check && Carrot_Seed)
        {
            Instan_Seed2();
        }
        if (!Seed3Check && Corn_Seed)
        {
            Instan_Seed3();
        }
        else
        {
            Scan_Seed = true;
            Debug.Log("이미 씨뿌림 ㅅㄱ");

            return;

        }


    }

    public void Get()
    {
        ani.SetTrigger("doHarv");
        StartCoroutine("Havr_Scan");
        ItemGet = true;
    }


    void Instan_Seed1()
    {  
            Instantiate(Seed1, Target.position, Quaternion.identity);
            Instantiate(Seed1, Target2.position, Quaternion.identity);
            Instantiate(Seed1, Target3.position, Quaternion.identity);
            Instantiate(Seed1, Target4.position, Quaternion.identity);
            Seed1Check = true;
            Weat_Seed = false;
            Scan_Seed = false;

    }

    void Instan_Seed2()
    {
        Instantiate(Seed2, Target.position, Quaternion.identity);
        Instantiate(Seed2, Target2.position, Quaternion.identity);
        Instantiate(Seed2, Target3.position, Quaternion.identity);
        Instantiate(Seed2, Target4.position, Quaternion.identity);
        Seed2Check = true;
        Carrot_Seed = false;
        Scan_Seed = false;
    }

    void Instan_Seed3()
    {
        Instantiate(Seed3, Target.position, Quaternion.identity);
        Instantiate(Seed3, Target2.position, Quaternion.identity);
        Instantiate(Seed3, Target3.position, Quaternion.identity);
        Instantiate(Seed3, Target4.position, Quaternion.identity);
        Seed3Check = true;
        Corn_Seed = false;
        Scan_Seed = false;
    }


    public void Dig_B()
    {
        if (EquitTool)
        {
            Debug.Log("눌렸다");
            StartCoroutine("Area_Active");
            ani.SetTrigger("doDigB");
            Debug.Log("장비낌");
        }
        if (!EquitTool)
        {
            Debug.Log("장비안낌");
            return;
            
        }
    }
      


    public void Active()
    {
        clickCnt++;
        Tool.SetActive(true);
        EquitTool = true;
        if (clickCnt >= 2)
        {
            Tool.SetActive(false);
            EquitTool = false;
            clickCnt = 0;

        }
        if (clickCnt <= 1)
        {
            image.GetComponent<Image>().color = new Color(156, 156, 156);
        }
        



    }
    



    IEnumerator Area_Active()
    {
        yield return new WaitForSeconds(0.2f);
        Area.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Area.enabled = false; 
    }

    IEnumerator Havr_Scan()
    {
        yield return new WaitForSeconds(0.3f);
        Havr_Area.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Havr_Area.enabled = false;
    }



    public void InvenOpen()
    {
        Inventory.SetActive(true); 
        
        
    }

    public void InvenExit()
    {
        Inventory.SetActive(false);
    }

    void InfoItem()
    {
        Count_Text.text = Weat.ToString();


    }

    public void Changeimage()
    {
        itemimage.sprite = change_item; 
    }

    public void StoreExit()
    {
        store.SetActive(false);
    }

}
