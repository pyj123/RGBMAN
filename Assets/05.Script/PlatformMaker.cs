using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMaker : MonoBehaviour
{
    [SerializeField]
    private Platform platformPrefab;
    [SerializeField]
    private ObjectMaker objectMaker;

    [SerializeField]
    private Transform platformsParent;
    private ObjectPool<Platform> platformPool;

    [SerializeField]
    private Transform playerTr;


    //맨뒤 플랫폼 반환
    private Platform lastPlatForm;

    [SerializeField]
    private int FirstMakeNum;

    //경계값
    [SerializeField]
    private Columns columns;


    //설정값
    [SerializeField]
    private int intervalMin;
    [SerializeField]
    private int intervalMax;

    //이동발판 생성확률
    private int movePlatformProbability = 0;
    public int MovePlatformProbability
    {
        set
        {
            movePlatformProbability = value;
        }
    }

    #region Awake&Start
    private void Awake()
    {
        platformPool = new ObjectPool<Platform>(platformPrefab, 10, platformsParent);

        movePlatformProbability = LevelData.firstMovePlatformProbability;

    }

    private void Start()
    {
        MakeFirstPlatforms();

    }

    #endregion

    #region BrushMode

    private bool isBrushMode = false;
    private int brushPlatformMakeCount = 0;
    private RGBType brushType;


    public void StartBrushMode(RGBType rgbType)
    {
        SoundManager.Instance.PlaySoundEffect("Magic");
         
        //중복 진입시
        if (isBrushMode == true)
            EndBrushMode();

        isBrushMode = true;
        brushType = rgbType;
        ChangeAllPlatform(rgbType);
    }

    private void EndBrushMode()
    {
        isBrushMode = false;
        brushPlatformMakeCount = 0;
    }

    private void ChangeAllPlatform(RGBType rgbType)
    {
        if (platformPool == null) return;
        for (int i = 0; i < platformPool.Datas.Count; i++)
        {
            platformPool.Datas[i].Initialize(rgbType);
        }
    }

    #endregion

    #region PlatformMake
    public void MakeNextPlatform()
    {
        Vector2 posit = Vector2.zero;

        RGBType rgbType = (RGBType)Random.Range((int)RGBType.Red, (int)RGBType.End);

        if (lastPlatForm != null)
        {
            float x = Random.Range(columns.LeftTr.position.x + 0.5f, columns.RightTr.position.x - 0.5f);
            float y = lastPlatForm.CenterTile.transform.position.y + Random.Range(intervalMin, intervalMax);

            posit.Set(x, y);
        }

        Platform targetPlatform = platformPool.GetItem();
        if (targetPlatform != null)
        {
            //맨처음 발판
            if (posit == Vector2.zero)
                rgbType = RGBType.All;

            //브러쉬 모드
            if (isBrushMode == true)
            {
                targetPlatform.Initialize(brushType);
                brushPlatformMakeCount++;
                if (brushPlatformMakeCount >= ItemData.BrushPlatformMakeNum)
                {
                    EndBrushMode();
                }
            }
            //일반모드
            else
            {
                targetPlatform.Initialize(rgbType);
            }




            targetPlatform.SetProperties(playerTr, this);
            targetPlatform.transform.position = posit;

            #region PlatformType
            //이동발판
            if (MyUtil.GetPercentageResult(movePlatformProbability) == true)
                targetPlatform.SetPlatformType(PlatformType.HorizontalMove);
            #endregion



            #region ItemMake
           

            //발판에 아이템 생성
            if (MyUtil.GetPercentageResult(Probabilities.WingSpawnProbabiliy) == true
                && rgbType != RGBType.All)
            {
                objectMaker.SpawnDropItem(DropItemType.Wing, targetPlatform.transform);

            }

            if (MyUtil.GetPercentageResult(Probabilities.BrushSpawnProbability)
                && rgbType != RGBType.All
                &&isBrushMode==false)
            {
                objectMaker.SpawnDropItem(DropItemType.Brush, targetPlatform.transform, rgbType);
            }

            #endregion


            lastPlatForm = targetPlatform;
        }
    }

    private void MakeFirstPlatforms()
    {
        if (platformPool == null) return;


        for (int i = 0; i < FirstMakeNum; i++)
        {
            MakeNextPlatform();
        }

    }


    #endregion

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeAllPlatform(RGBType.Red);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeAllPlatform(RGBType.Green);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeAllPlatform(RGBType.Blue);
        }
    }
#endif



}
