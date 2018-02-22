using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorFrame : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }


    public void SetColor(RGBType rgbType)
    {
        if (image == null) return;

        switch (rgbType)
        {
            case RGBType.Red:
                {
                    image.color = Color.red;
                } break;
            case RGBType.Green:
                {
                    image.color = Color.green;
                }
                break;

            case RGBType.Blue:
                {
                    image.color = Color.blue;
                }
                break;
            default:
                {
                    image.color = Color.black;
                } break;
        }
    } 
}
