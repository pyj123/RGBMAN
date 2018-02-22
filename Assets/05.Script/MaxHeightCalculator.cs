using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHeightCalculator : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private RisingObject risingObject;

    [SerializeField]
    private PlatformMaker platformMaker;

    private float maxHeight = 0f;
    public float MaxHeight
    {
        get
        {
            return maxHeight;
        }
    }


    private void ChangeLevel()
    {
        switch (GameConstant.gameLevel)
        {
            case GameLevel.first:
                {
                    if (maxHeight >= GameConstant.firstPoint)
                    {
                        GameConstant.gameLevel = GameLevel.second;

                        if (risingObject != null)
                            risingObject.SetRisingSpeed(LevelData.secondRisingSpeed);

                        if (platformMaker != null)
                            platformMaker.MovePlatformProbability = LevelData.secondMovePlatformProbability;


                        SoundManager.Instance.SetBGMPitch(LevelData.firstPitchValue);
                    }
                }
                break;
            case GameLevel.second:
                {
                    if (maxHeight >= GameConstant.secondPoint)
                    {
                        GameConstant.gameLevel = GameLevel.third;

                        if (risingObject != null)
                            risingObject.SetRisingSpeed(LevelData.thirdRisingSpeed);

                        if (platformMaker != null)
                            platformMaker.MovePlatformProbability = LevelData.thirdMovePlatformProbability;

                        SoundManager.Instance.SetBGMPitch(LevelData.secondPitchValue);
                    }
                }
                break;

        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        CalMaxHeight();
    }


    private void CalMaxHeight()
    {
        float nowHeight = target.transform.position.y;
        if (nowHeight > maxHeight)
        {
            maxHeight = nowHeight;
            ChangeLevel();
        }
    }
}
