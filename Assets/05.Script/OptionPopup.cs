using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionPopup : MonoBehaviour
{
    [SerializeField]
    private Image BgmImage;
    [SerializeField]
    private Image EffectImage;

    private void OnEnable()
    {
        UpdateButtonImages();
    }

    //0 true 1 false
    public void BGMButtonClick()
    {
        if (SoundManager.Instance.IsBgmMute == true)
        {
            PlayerPrefs.SetInt(PlayerPrefKeys.BgmMuteKey, 1);
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefKeys.BgmMuteKey, 0);
        }

        UpdateButtonImages();
        SoundManager.Instance.SetBgmMute();

        SoundManager.Instance.PlaySoundEffect("Button");
    }
    public void EffectButtonClick()
    {
        if (SoundManager.Instance.IsEffectMute == true)
        {
            PlayerPrefs.SetInt(PlayerPrefKeys.EffectMuteKey, 1);
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefKeys.EffectMuteKey, 0);
        }

        UpdateButtonImages();

        SoundManager.Instance.PlaySoundEffect("Button");
    }

    private void UpdateButtonImages()
    {
        if (SoundManager.Instance.IsBgmMute == true)
        {
            BgmImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        else
        {
            BgmImage.color = new Color(1f, 1f, 1f, 1f);
        }

        if (SoundManager.Instance.IsEffectMute == true)
        {
            EffectImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        else
        {
            EffectImage.color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
