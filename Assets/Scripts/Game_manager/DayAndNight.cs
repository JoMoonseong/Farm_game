using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    public GameObject Water;
    public ParticleSystem WaterEffect_L;
    public ParticleSystem WaterEffect_R;

    public static DayAndNight instance;

    [SerializeField]
    private float ScecondPerRealTimeSecound;

    public bool isNight = false;

    [SerializeField]
    private float fogDesityCalc;

    [SerializeField]
    private float nightFogDensity;
    private float dayFogDensity;
    private float currentFogDesity;

    
    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
    }

    
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * ScecondPerRealTimeSecound * Time.deltaTime);



        if (transform.eulerAngles.x >= 170)
        
            isNight = true;

        else if (transform.eulerAngles.x <= 340)
                isNight = false;

        if (isNight)
        {
            if (currentFogDesity <= nightFogDensity)
            {
                currentFogDesity += 0.1f * fogDesityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDesity;
            }
              
        }
        else
        {
            if (currentFogDesity >= dayFogDensity)
            {
                currentFogDesity -= 0.1f * fogDesityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDesity;
            }
        }
            if (isNight)
            {
                WaterEffect_L.Stop();
                WaterEffect_R.Stop();
            }
            if (!isNight)
            {
                Water.transform.Rotate(Vector3.up * Time.deltaTime * 200);
                WaterEffect_L.Play();
                WaterEffect_R.Play();
            }
            else if (currentFogDesity >= dayFogDensity)
            {
                WaterEffect_L.Play();
                WaterEffect_R.Play();
            }
    }
}
