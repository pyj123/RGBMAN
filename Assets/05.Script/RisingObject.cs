using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingObject : MonoBehaviour
{
    [SerializeField]
    private float risingSpeed =1f;

    [SerializeField]
    private InGameUI ingameUI;

    [SerializeField]
    private MaxHeightCalculator maxHeight;

    private bool nowRising = true;

    //테스트
    private void Awake()
    {
        risingSpeed = GameConstant.LisingObjectSpeed;
        SetRisingSpeed(LevelData.firstRisingSpeed);
    }

    public void ReviveAction()
    {
        nowRising = true;
    }

    private void Update()
    {
        Rising();
    }

    private void Rising()
    {
        if (nowRising == false) return;
        this.transform.position += Vector3.up * risingSpeed * Time.deltaTime;
   
    }

    public void SetRisingSpeed(float speed)
    {
        risingSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SoundManager.Instance.PlaySoundEffect("Dead");

#if UNITY_EDITOR
            Debug.Log("Player overlap");
#endif

            RisingStop();
        //    Invoke("RisingStop", 1f);
      
        }
    }

    private void RisingStop()
    {
        nowRising = false;
        if (ingameUI != null)
            ingameUI.WhenPlayerDead();
    }


}
