using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void SetSpriteSize(int size)
    {
        Vector2 sizeVector = new Vector2(size, 1);

        if (spriteRenderer != null)
            spriteRenderer.size = sizeVector;

  

    }

    public void SetColliderSize(int size)
    {
    
        if (boxCollider2D != null)
        {
            Vector2 sizeVector = new Vector2(size, 0.01f);
            boxCollider2D.size = sizeVector;
            boxCollider2D.offset = new Vector2(0f, 0.5f);
        }
    }






}
