using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartCounter : MonoBehaviour
{
    [SerializeField]
    Image maskImage;

    [SerializeField]
    Text text;

    private bool isGameStart = false;

    private void Awake()
    {
    
    }
   
    private void OnEnable()
    {
        StopTime();
        SetCount(3);
    }

    private void StopTime()
    {
        Time.timeScale = 0f;
    }
    private void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }

    private float nowTimeCount =0f;
    int nowCount = 3;

    private void OnDisable()
    {
        nowTimeCount = 0f;
        nowCount = 3;
        ResumeTime();
    }

    private void Update()
    {    

        nowTimeCount += Time.unscaledDeltaTime;
        if (nowTimeCount >= 0.5f)
        {
            nowCount--;
            SetCount(nowCount);
            nowTimeCount = 0f;
        }
    }

    private void GameStart()
    {  
        this.gameObject.SetActive(false);      
    }

  


    private void SetCount(int nowCount)
    {
        if (nowCount == 0)
        {
            if (text != null)
                text.text = "Go!";      
        }
        //게임 시작
        else if(nowCount == -1)
        {
            GameStart();
        }
        else
        {
            if (text != null)
                text.text = nowCount.ToString();
        }



    }

 
}
