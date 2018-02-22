using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SparkEffect : MonoBehaviour
{
    ParticleSystem particleSystem;

    [SerializeField]
    private Gradient redColor;
    [SerializeField]
    private Gradient greenColor;
    [SerializeField]
    private Gradient blueColor;

    [SerializeField]
    private float lifeTime =1f;

    ParticleSystem.ColorOverLifetimeModule color;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();  
        color =  particleSystem.colorOverLifetime;

        Initialize(RGBType.Green);
    }

    public void Initialize(RGBType rgbType)
    {
        switch (rgbType)
        {
            case RGBType.Red:
                {                    
                    color.color = redColor;

                } break;
            case RGBType.Green:
                {
                    color.color = greenColor;
                } break;
            case RGBType.Blue:
                {
                    color.color = blueColor;
                } break;
        }


        Invoke("EffectOff", lifeTime);
    }

    private void EffectOff()
    {
        this.gameObject.SetActive(false);
    }

#if UNITY_EDITOR

 
#endif



}
