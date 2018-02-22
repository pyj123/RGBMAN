using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterEffector : MonoBehaviour
{
   [SerializeField]
    private CharacterAttacker characterAttacker;
    [SerializeField]
    private ObjectMaker objectMaker;


    public void MakeSparkEffect(Vector3 posit)
    {
        if (objectMaker == null|| characterAttacker==null) return;
        

        SparkEffect effect = objectMaker.GetSparkEffect();
        if (effect != null)
        {
            effect.Initialize(characterAttacker.NowRGBType);
            effect.transform.position = posit;
        }
    }
  
}
