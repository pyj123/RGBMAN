using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorChanger : MonoBehaviour
{

    [SerializeField]
    private Text text;

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private List<Color> colorList;
    private Color prefColor;

  
    // Use this for initialization
    void Start ()
    {
        text.color = Color.white;
        StartCoroutine(colorChangeRoutine());

    }

    private IEnumerator colorChangeRoutine()
    {
        prefColor = Color.blue;
        float count = 0f;       
        while (true)
        {
            for(int i = 0; i < colorList.Count; i++)
            {
                while (true)
                {
                    text.color = Color.Lerp(prefColor, colorList[i], count);
                    
                    count += Time.deltaTime* speed;
                    if (count >= 1)
                    {
                        prefColor = colorList[i];
                        count = 0f;                  
                        break;
                    }
                    yield return null;
                }
            
            }
        
          

        }
    }
	

}
