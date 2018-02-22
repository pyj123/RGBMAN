using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingObjectTest : MonoBehaviour
{
#if UNITY_EDITOR
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
#endif


}
