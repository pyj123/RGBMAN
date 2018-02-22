using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum characterStyle
{
    Basic,
    Devil,
    GreenMan,
    Alien,
    Elvis,
    Thief,
    WhatMan,
    Gombo,
    CharacterStyleEnd
}

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private Material material;
    private Animator animator;


    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        animator = GetComponent<Animator>();
        SetCharacterAnimator();
    }

    private void SetCharacterAnimator()
    {
        if (animator == null) return;

        string animatorName = ((characterStyle)PlayerPrefs.GetInt(PlayerPrefKeys.CharacterStyleKey, 0)).ToString();
        RuntimeAnimatorController loadAnim = Resources.Load<RuntimeAnimatorController>(string.Format("Animators/Characters/{0}", animatorName));
        if (loadAnim != null)
        {
            animator.runtimeAnimatorController = loadAnim;

        }
    }

    public void ChangeColor(Color color)
    {
        if (material != null)
        {
            material.SetColor("_Color", color);
        }          

    }


}
