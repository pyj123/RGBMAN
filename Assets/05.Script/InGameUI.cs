using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private GameObject AdPopup;

    [SerializeField]
    private GameObject resultPopup;

    [SerializeField]
    private CameraController cameraController;

    private bool isReviveUse = false;
    private bool isPlayerDead = false;

    public void PauseUIOnOff()
    {
        if (pauseUI == null) return;
        pauseUI.SetActive(!pauseUI.activeSelf);

        SoundManager.Instance.PlaySoundEffect("Button");
    }

    public void WhenPlayerDead()
    {
        if (isPlayerDead == true) return;

        if (cameraController != null)
            cameraController.IsPlayerDead = true;

        isPlayerDead = true;

        Invoke("PlayerDeadAction", 1.0f);
    }

    private void PlayerDeadAction()
    {
        //부활 썻다
        if (isReviveUse == true)
        {
            AdPopup.SetActive(false);
            ResultPopupOn();
            return;
        }

        if (AdPopup == null) return;
        isPlayerDead = false;
        isReviveUse = true;
        AdPopup.SetActive(true);

        //시점이동 제어
        if (cameraController != null)
            cameraController.IsPlayerDead = false;
    }

    public void ResultPopupOn()
    {
        if (resultPopup == null) return;
        resultPopup.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (AdPopup.activeSelf == false && resultPopup.activeSelf == false)
            {
                PauseUIOnOff();
            }
        }
    }

}
