using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdPopUp : MonoBehaviour
{
    [SerializeField]
    private RevivePlayer reviveFunc;

    [SerializeField]
    private InGameUI ingameUI;
 

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
 

    public void ContinueButtonClick()
    {      
        if (reviveFunc == null) return;

        UnityAdsHelper.Instance.LinkFunc = () =>
        {
            reviveFunc.ReviveFunc();
            ClosePopup();
        }; 
        UnityAdsHelper.Instance.ShowRewardedAd();   


    }
    private void ClosePopup()
    {
        this.gameObject.SetActive(false);

    }


    public void NoButtonClick()
    {
        //결과팝업켜기
        if (ingameUI == null) return;
        ClosePopup();
        ingameUI.ResultPopupOn();
    }
    
}
