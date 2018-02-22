using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState
{
    Idle,
    Run,
    Jump,
    Down,
    Dead
}

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
   
    private CharacterJump characterJump;

    private SpriteRenderer spriteRenderer;
    
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterJump = GetComponent<CharacterJump>();
        animator = GetComponent<Animator>();
    }


    public void PlayerAnim(AnimState state)
    {
        if (animator == null) return;
        if (characterJump == null) return;
        if (characterJump.NowPowerJump == true)
        {
            return;
        }

        switch (state)
        {
            case AnimState.Jump:
                {
                    animator.ResetTrigger("DownTrigger");
                    animator.SetTrigger("JumpTrigger");
                }
                break;
            case AnimState.Dead:
                {
                    animator.SetTrigger("DeadTrigger");
                }
                break;
            case AnimState.Down:
                {
                    animator.ResetTrigger("JumpTrigger");
                    animator.SetTrigger("DownTrigger");                    
                } break;
        }
    }

    public void SetSpeed(float speed)
    {
        if (characterJump == null) return;
        if (characterJump.NowPowerJump == true)
        {
            return;
        }

        if (animator != null)
            animator.SetFloat("Speed", speed);

    }
    public void SetFlip(bool OnOff)
    {
        if (spriteRenderer != null)
            spriteRenderer.flipX = OnOff;

    }


}
