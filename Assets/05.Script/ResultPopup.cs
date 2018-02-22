using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultPopup : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private MaxHeightCalculator data;

    private float maxHeight;

    private float reportScore = 0f;

    private GoogleService googleService;

    [SerializeField]
    private PlatformCounter counter;

    private void Awake()
    {
        googleService = GoogleService.Instance;
    }  

    private void OnEnable()
    {
        SoundManager.Instance.PlaySoundEffect("End");
        Time.timeScale = 0f;
        UpdateScore();
        ReportScore();
        ReportAchivement();
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        if (data == null) return;

        string score = data.MaxHeight.ToString("N1");

        reportScore = float.Parse(score);

        if (scoreText != null)
            scoreText.text = string.Format("{0}M", reportScore);

    }

    private void ReportAchivement()
    {
        if (counter != null)
            counter.ReportPlatformData();

        if (googleService != null)
        {  
            googleService.ReportSocialHeight((int)reportScore);
        }
    }

    private void ReportScore()
    {
        if (googleService != null)
        {
            googleService.ReportScore((int)reportScore);    
        }
    }

    public void MenuButtonClick()
    {
        SceneManager.LoadSceneAsync((int)SceneName.LobbyScene);

        SoundManager.Instance.PlaySoundEffect("Button");
    }

    public void RetryButtonClick()
    {
        SceneManager.LoadSceneAsync((int)SceneName.GameScene);

        SoundManager.Instance.PlaySoundEffect("Button");
    }

}
