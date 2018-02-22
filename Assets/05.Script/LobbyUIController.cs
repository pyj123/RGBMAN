using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject characterSelectPopup;

    [SerializeField]
    private GameObject OptionPopup;

    [SerializeField]
    private GameObject ExitPopup;

    [SerializeField]
    private GameObject TutorialUI;

    public void TutorialUIOnOff()
    {
        if (TutorialUI == null) return;
        TutorialUI.SetActive(!TutorialUI.activeSelf);

        SoundManager.Instance.PlaySoundEffect("Button");
    }


    public void characterSelectPopUpOnOff()
    {
        if (characterSelectPopup == null) return;
        characterSelectPopup.SetActive(!characterSelectPopup.activeSelf);

        SoundManager.Instance.PlaySoundEffect("Button");
    }

    public void OptionPopUpOnOff()
    {
        if (OptionPopup == null) return;
        OptionPopup.SetActive(!OptionPopup.activeSelf);

        SoundManager.Instance.PlaySoundEffect("Button");
    }

    public void RankingButtonClick()
    {
        GoogleService.Instance.ShowLeaderBoardUi();
    }
    
    public void AchievementButtonClick()
    {
        GoogleService.Instance.ShowAchivement();
    }

    public void ExitPopupOnOff()
    {
        if (ExitPopup == null) return;

        ExitPopup.SetActive(!ExitPopup.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPopupOnOff();
        }
    }



}
