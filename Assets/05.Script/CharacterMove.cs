using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 1f;


    private CharacterAnimator animationController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<CharacterAnimator>();
    }

    private void FixedUpdate()
    {
        float h = 0f;

#if UNITY_EDITOR
        //editor 디버그 용
        h = Input.GetAxisRaw("Horizontal");
        Move(h);

#else
        //휴대폰 
        h = Input.acceleration.x; 
             Move(h*4f);
           
#endif
    }

    private void Move(float h)
    {
        if (rb == null) return;
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if (animationController != null)
        {
            animationController.SetSpeed(h);

            if (Mathf.Abs(0 - h) > 0.1)
                animationController.SetFlip(h < 0 ? true : false);
        }

    }

}
