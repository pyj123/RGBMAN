using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    [SerializeField]
    MaxHeightCalculator maxHeightCalculator;

    [SerializeField]
    private float followSpeed = 10f;

    [SerializeField]
    private float xOffset = 0f;
    [SerializeField]
    private float yOffset= 2.165f;
    [SerializeField]
    private float distance = 0f;

    private bool isPlayerDead = false;
    public bool IsPlayerDead
    {
        set
        {
            isPlayerDead = value;
        }
    }

    [SerializeField]
    private Transform target;

#if UNITY_EDITOR
    private void OnValidate()
    {
        FixedUpdate();
    }
#endif

 
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (isPlayerDead == false)
        {
            if (maxHeightCalculator == null) return;
            Vector3 moveTargetPos = new Vector3(0, maxHeightCalculator.MaxHeight, 0) + new Vector3(xOffset, yOffset, -distance);
            //  this.transform.position = Vector3.Lerp(this.transform.position, moveTargetPos, followSpeed * Time.fixedDeltaTime);
            this.transform.position = moveTargetPos;
        }
        else if (isPlayerDead == true)
        {
            if(target!=null)
            this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position,5f*Time.fixedDeltaTime);
        }

  
    }

 
}
