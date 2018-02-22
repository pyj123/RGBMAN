using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistPlayerAndRisingObj : MonoBehaviour
{
    [SerializeField]
    Transform playerTr;
    [SerializeField]
    Transform risingObjTr;

    private float offsetY = 0f;

    private float distance = 0f;
    private float Distance
    {
        get
        {
            return distance;
        }
    }

    private void Awake()
    {
        if (risingObjTr != null)
            offsetY = risingObjTr.transform.localScale.y / 2;
    }

    void Update()
    {
        CalDistance();
    }

    private void CalDistance()
    {
        if (playerTr == null || risingObjTr == null) return;
        distance = offsetY + playerTr.position.y - risingObjTr.position.y;
    }

 
}
