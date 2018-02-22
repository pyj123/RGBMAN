using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class RisingObjDistanceLabel : MonoBehaviour
{
    [SerializeField]
    RisingObjDistanceChecker data;

    [SerializeField]
    Text text;

    void Update ()
    {
        UpdateData();
    }

     private void UpdateData()
    {
        if (data == null || text == null) return;
        text.text = string.Format("{0}M", data.Distance.ToString("N1"));
    }
}
