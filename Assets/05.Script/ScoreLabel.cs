using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreLabel : MonoBehaviour
{
    //최대 높이 정보가 여기 있음
    [SerializeField]
    private MaxHeightCalculator data;

    [SerializeField]
    private Text text;

    private void UpdateScore()
    {
        if (data == null || text == null) return;
        text.text = string.Format("{0}M", data.MaxHeight.ToString("N1")); 

    }

    private void Update()
    {
        UpdateScore();
    }

}
