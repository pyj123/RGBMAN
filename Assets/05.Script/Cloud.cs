using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cloud : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector3 posit,float speed,float lifeTime)
    {
        this.transform.position = posit;
        moveSpeed = speed;
        

        //if (rb != null)
        //    rb.velocity =Vector3.down*speed;


        Invoke("CloudOff", lifeTime);
    }

    private void FixedUpdate()
    {
        this.transform.position -= Vector3.up * moveSpeed * Time.fixedDeltaTime;
    }

    private void CloudOff()
    {
        this.gameObject.SetActive(false);
    }
 
}
