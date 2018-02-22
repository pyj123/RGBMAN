using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed =10f;

    float x;
    float y;

    void Update()
    {
        x += Time.deltaTime * rotateSpeed;
        y += Time.deltaTime * rotateSpeed;
        this.transform.rotation = Quaternion.Euler(new Vector3(x, y, 0));
    }
	
}
