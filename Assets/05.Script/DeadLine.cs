using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField]
    private InGameUI ingameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SoundManager.Instance.PlaySoundEffect("Dead");

#if UNITY_EDITOR
            Debug.Log("Player overlap In DeadLine");
#endif

            PlayerOverlap();      

        }
    }

    private void PlayerOverlap()
    {       
        if (ingameUI != null)
            ingameUI.WhenPlayerDead();
    }

}
