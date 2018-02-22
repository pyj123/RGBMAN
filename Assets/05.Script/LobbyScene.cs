using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScene : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        SoundManager.Instance.PlayBgm("Lobby",true);
        SoundManager.Instance.SetBGMPitch(1f);
        GoogleService.Instance.AchievementClearCheck();
    }


   
} 
