using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RGBType
{
    All,
    Red,
    Green,
    Blue,
    End
}

public enum PlatformType
{
    Normal,
    HorizontalMove,
}

public class Platform : MonoBehaviour
{
    private PlatformMaker platformMaker;
    private ObjectPool<Platform> parentPool;
    private Transform playerTr;
    private PlatformType platformType = PlatformType.Normal;
    private float moveSpeed = 2f;


    [SerializeField]
    private Tile centerTile;

    public Tile CenterTile
    {
        get
        {
            return centerTile;
        }
    }


    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetParent(ObjectPool<Platform> parent)
    {
        if (this.parentPool == null)
            this.parentPool = parent;
    }

    private void Update()
    {
        if (playerTr.transform.position.y > centerTile.transform.position.y + GameConstant.PlatformDestroyDistance)
        {
            PlatformOff();           
        }
    }


    private enum MoveDirection
    {
        left,right,down,up
    }

    private IEnumerator MoveHorizontal()
    {

        MoveDirection moveDirection = (MoveDirection)UnityEngine.Random.Range(0, 2);
        moveSpeed = UnityEngine.Random.Range(1f, PlatformData.GetMaximumSpeed);

        while (true)
        {
            if (moveDirection == MoveDirection.left)
            {
                this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                if (this.transform.position.x <= GameConstant.LeftEndPosit+GameConstant.HorizontalMoveOffset)
                {
                    moveDirection = MoveDirection.right;
                }
            }
            else if (moveDirection == MoveDirection.right)
            {
                this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                if (this.transform.position.x >= GameConstant.RightEndPosit-GameConstant.HorizontalMoveOffset)
                {
                    moveDirection = MoveDirection.left;
                }
            }

            yield return null;
        }
   
    }
    private IEnumerator MoveVertical()
    {

        yield break;
    }


    //소멸
    private void PlatformOff()
    {
        if (platformMaker != null)
            platformMaker.MakeNextPlatform();

        StopAllCoroutines();

        this.gameObject.SetActive(false);
    }

    public void SetProperties(Transform playerTr, PlatformMaker platformMaker)
    {
        if (this.playerTr == null)
            this.playerTr = playerTr;

        if (this.platformMaker == null)
            this.platformMaker = platformMaker;
    }

    public void SetPlatformType(PlatformType platformType)
    {
        this.platformType = platformType;

        switch (platformType)
        {
            case PlatformType.HorizontalMove:
                {
                    StartCoroutine(MoveHorizontal());
                } break;      

        }



    }

    public void Initialize(RGBType rgbType)
    {   
        SetLayerAndSprite(rgbType);  
    }

    private void SetLayerAndSprite(RGBType rgbType)
    {
#if UNITY_EDITOR
       // rgbType = RGBType.All;
#endif

        Color targetColor = Color.black;
        int layerMask = LayerMask.NameToLayer(LayerName.All);

        switch (rgbType)
        {
            case RGBType.Red:
                {
                    targetColor = Color.red;
                    layerMask = LayerMask.NameToLayer(LayerName.Red);
                }
                break;
            case RGBType.Green:
                {
                    targetColor = Color.green;
                    layerMask = LayerMask.NameToLayer(LayerName.Green);
                }
                break;
            case RGBType.Blue:
                {
                    targetColor = Color.blue;
                    layerMask = LayerMask.NameToLayer(LayerName.Blue);
                }
                break;
        }



        if (spriteRenderer != null)
            spriteRenderer.color= targetColor;     

        if (centerTile != null)
            centerTile.gameObject.layer = layerMask;

    }



}
