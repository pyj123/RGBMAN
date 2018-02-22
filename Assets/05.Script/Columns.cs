using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour
{
    public float distance = 10;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform leftTr;
    [SerializeField]
    private Transform rightTr;

    public Transform LeftTr
    {
        get
        {
            return leftTr;
        }
    }

    public Transform RightTr
    {
        get
        {
            return rightTr;
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (leftTr != null)
            leftTr.position = new Vector3(-distance / 2, 0, 0);

        if (rightTr != null)
            rightTr.position = new Vector3(+distance / 2, 0, 0);
    }
#endif

    private void Awake()
    {
        SetConstants();
    }

    private void SetConstants()
    {
        if (leftTr != null)
            GameConstant.LeftEndPosit = leftTr.position.x;

        if (rightTr != null)
            GameConstant.RightEndPosit = rightTr.position.x;
    }


    // Update is called once per frame
    void Update()
    {
        TeleportPlayer();
    }


    void TeleportPlayer()
    {
        if (target.position.x >= rightTr.position.x)
        {
            target.position = new Vector3(leftTr.position.x, target.position.y, 0f);
        }
        else if (target.position.x <= leftTr.position.x)
        {
            target.position = new Vector3(rightTr.position.x, target.position.y, 0f);
        }
    }
}
