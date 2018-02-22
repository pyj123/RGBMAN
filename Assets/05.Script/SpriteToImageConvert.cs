using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Image))]
public class SpriteToImageConvert : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Image image;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (spriteRenderer == null || image == null) return;

        if (spriteRenderer.sprite != null)
            image.sprite = spriteRenderer.sprite;

    }
}
