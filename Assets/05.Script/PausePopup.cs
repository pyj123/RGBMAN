using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePopup : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }

    public void MenuButtonClick()
    {
        SceneManager.LoadSceneAsync((int)SceneName.LobbyScene);

        SoundManager.Instance.PlaySoundEffect("Button");
    }
    public void ResumeButtonClick()
    {
        this.gameObject.SetActive(false);

        SoundManager.Instance.PlaySoundEffect("Button");
    }
    public void RetryButtonClick()
    {
        SceneManager.LoadSceneAsync((int)SceneName.GameScene);

        SoundManager.Instance.PlaySoundEffect("Button");
    }

}
