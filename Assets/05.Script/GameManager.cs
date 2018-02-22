using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
      
        SoundManager.Instance.PlayBgm("InGame", true);
        SoundManager.Instance.SetBGMPitch(1f);
        GameConstant.gameLevel = GameLevel.first; ;

    }

    public void ReStartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
