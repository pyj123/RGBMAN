using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DropItemType
{
    Wing,
    Brush
}

[RequireComponent(typeof(SpriteRenderer))]
public class DropItem : MonoBehaviour
{
    private DropItemType itemType;
    private SpriteRenderer spriteRenderer;
    private PlatformMaker platformMaker;
    private RGBType rgbType;

    public void Initialize(Transform targetTr, DropItemType itemType, RGBType rgbType)
    {
        this.rgbType = rgbType;
        this.transform.parent = targetTr;
        this.transform.localPosition = Vector3.up * 0.7f;
        this.itemType = itemType;
        ChangeColor(rgbType);
        ChangeSprite(itemType);
    }

    private void ChangeSprite(DropItemType itemType)
    {
        if (spriteRenderer == null) return;
        Sprite sprite = Resources.Load<Sprite>(string.Format("Item/{0}", itemType.ToString()));
        if (sprite != null)
        {
            spriteRenderer.sprite = sprite;
        }

    }



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
  
    }

    private void Start()
    {
        GameObject platformMakerObj = GameObject.Find("PlatformMaker");
        if (platformMakerObj != null)
        {
            platformMaker = platformMakerObj.GetComponent<PlatformMaker>();
        }
    }

    private void OnDisable()
    {
        this.gameObject.SetActive(false);
    }

    private void ChangeColor(RGBType rgbType)
    {
        if (spriteRenderer == null) return;

        Color color;

        switch (rgbType)
        {
            case RGBType.Red:
                {
                    color = Color.red;
                }
                break;
            case RGBType.Green:
                {
                    color = Color.green;
                }
                break;
            case RGBType.Blue:
                {
                    color = Color.blue;
                }
                break;
            default:
                {
                    color = Color.white;
                }
                break;
        }

        spriteRenderer.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            switch (itemType)
            {
                case DropItemType.Wing:
                    {
                        CharacterJump jump = collision.gameObject.GetComponent<CharacterJump>();
                        if (jump != null)
                            jump.PowerJump(ItemData.PowerJumpPower);

                        this.gameObject.SetActive(false);
                    }
                    break;
                case DropItemType.Brush:
                    {
                        if (platformMaker != null)
                            platformMaker.StartBrushMode(rgbType);
                        this.gameObject.SetActive(false);

#if UNITY_EDITOR
                        Debug.Log("Brush");
#endif
                    } break;
            }


        }
    }

}
