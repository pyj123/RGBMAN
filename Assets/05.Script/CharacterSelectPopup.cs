using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterSelectPopup : MonoBehaviour
{
    private characterStyle nowSelectCharacterStyle = characterStyle.Basic;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject GameStartButton;

    [SerializeField]
    private Image characterImage;

    private void Start()
    {
        ChangeImage();
        CharacterHasCheck();
    }

    private void CharacterHasCheck()
    {
        //있을때
        if (DBContainer.HasCharacter(nowSelectCharacterStyle) == true)
        {
            if (characterImage != null)
                characterImage.color = Color.white;

            if (GameStartButton != null)
                GameStartButton.gameObject.SetActive(true);
        }
        //없을때
        else
        {
            if (characterImage != null)
                characterImage.color = new Color(0.1f,0.1f,0.1f,1f);

            if (GameStartButton != null)
                GameStartButton.gameObject.SetActive(false);
        }
    }

    #region ButtonClick
    public void RightButtonClick()
    {
        if (nowSelectCharacterStyle < characterStyle.CharacterStyleEnd - 1)
        {
            nowSelectCharacterStyle++;
        }
        ChangeImage();
        CharacterHasCheck();

        SoundManager.Instance.PlaySoundEffect("Button");


    }

    public void LeftButtonClick()
    {
        if (nowSelectCharacterStyle > 0)
        {
            nowSelectCharacterStyle--;
        }
        ChangeImage();
        CharacterHasCheck();

        SoundManager.Instance.PlaySoundEffect("Button");
    }
    #endregion
    public void ChangeImage()
    {
        if (animator == null) return;

        RuntimeAnimatorController loadAnim = Resources.Load<RuntimeAnimatorController>(string.Format("Animators/Characters/{0}", nowSelectCharacterStyle.ToString()));
        if (loadAnim != null)
        {
            animator.runtimeAnimatorController = loadAnim;

        }
    }

    public void StartButtonClick()
    {
        PlayerPrefs.SetInt(PlayerPrefKeys.CharacterStyleKey, (int)nowSelectCharacterStyle);
        SceneManager.LoadSceneAsync((int)SceneName.GameScene);

        SoundManager.Instance.PlaySoundEffect("Button");

    }



}
