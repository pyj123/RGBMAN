using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using System.Text;
using UnityEngine.UI;


public class GoogleService : MonoBehaviour
{
    public static GoogleService Instance;

    private void Awake()
    {
        if (Instance == null)
        {
         
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        PlayGamesPlatform.Activate();
        LogIn();
    }

    public void LogIn()
    {
        PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            
        });

    }


    public bool NowLogIn()
    {
        return PlayGamesPlatform.Instance.IsAuthenticated();
    }

    public void ShowLeaderBoardUi()
    {
        if (NowLogIn())
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        else
            LogIn();


    }

    public void ShowAchivement()
    {
        if (NowLogIn())
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        else
            LogIn();
    }

    public void ReportScore(int score)
    {
        PlayGamesPlatform.Instance.ReportScore(score, GPGSIds.leaderboard_high_score, null);
    }

    public void ReportSocialPlatformData(RGBType rgbType, int value)
    {
        switch (rgbType)
        {
            case RGBType.Red:
                {
                    PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_character_devil, value, null);
                }
                break;
            case RGBType.Green:
                {
                    PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_character_greenman, value, null);
                }
                break;
            case RGBType.Blue:
                {
                    PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_character_bluealien, value, null);
                }
                break;
        }

    }

    public void ReportSocialHeight(int height)
    {
        if (height >= 100)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_100m, 100f, null);    
        }

        if (height >= 200)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_200m, 100f, null);     
        }

        if (height >= 300)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_300m, 100f, null);     
        }

        if (height >= 500)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_500m, 100f, null);
    
        }
    }

    public bool IsAchivementClear(string AchiveId)
    {
        var achivData = PlayGamesPlatform.Instance.GetAchievement(AchiveId);
        if (achivData != null)
        {
            if (achivData.IsUnlocked == true)
            {
                return true;
            }
            else if (achivData.IsUnlocked == false)
            {
                return false;
            }
        }
        else if (achivData == null)
        {
            return false;
        }
        return false;
    }

    public void AchievementClearCheck()
    {
        if (IsAchivementClear(GPGSIds.achievement_100m) == true)
        {
            if (DBContainer.HasCharacter(characterStyle.Elvis) == false)
                DatabaseLoader.Instance.UnlockCharacter(characterStyle.Elvis);
        }
        if (IsAchivementClear(GPGSIds.achievement_200m) == true)
        {
            if (DBContainer.HasCharacter(characterStyle.Thief) == false)
                DatabaseLoader.Instance.UnlockCharacter(characterStyle.Thief);
        }
        if (IsAchivementClear(GPGSIds.achievement_300m) == true)
        {
            if (DBContainer.HasCharacter(characterStyle.WhatMan) == false)
                DatabaseLoader.Instance.UnlockCharacter(characterStyle.WhatMan);
        }
        if (IsAchivementClear(GPGSIds.achievement_500m) == true)
        {
            if (DBContainer.HasCharacter(characterStyle.Gombo) == false)
                DatabaseLoader.Instance.UnlockCharacter(characterStyle.Gombo);
        }
        if (IsAchivementClear(GPGSIds.achievement_character_devil) == true)
        {
            if (DBContainer.HasCharacter(characterStyle.Devil) == false)
                DatabaseLoader.Instance.UnlockCharacter(characterStyle.Devil);
        }
        if (IsAchivementClear(GPGSIds.achievement_character_greenman) == true)
        {
            if (DBContainer.HasCharacter(characterStyle.GreenMan) == false)
                DatabaseLoader.Instance.UnlockCharacter(characterStyle.GreenMan);
        }
        if (IsAchivementClear(GPGSIds.achievement_character_bluealien) == true)
        {
            if (DBContainer.HasCharacter(characterStyle.Alien) == false)
                DatabaseLoader.Instance.UnlockCharacter(characterStyle.Alien);
        }
    }



    ////업적
    //public void ReportSocial(int type)
    //{
    //    if (NowLogIn())
    //    {
    //        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_get_a_scientist, 1, (bool success) =>
    //        {
    //            if (success == true)
    //            {

    //            }
    //        });


    //    }
    //}




}
