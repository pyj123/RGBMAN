using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    first,
    second,
    third

}

public static class GameConstant
{
    //플레이어와의 거리가 얼마나 돼야 발판이 사라지는가
    public const int PlatformDestroyDistance = 5;
    public const string CenterPlatformName = "Center";
    public const float PlayerJumpPower = 8;

    //Columns에서 초기화
    public static float LeftEndPosit = 0f;
    public static float RightEndPosit = 0f;
    public static float HorizontalMoveOffset = 1f;

    public static float LisingObjectSpeed = 2.5f;

    public static GameLevel gameLevel = GameLevel.first;




    public const float firstPoint = 100f;
    public const float secondPoint = 300f;
    //  public const float thirdPoint = 200f;



}

public static class PlatformData
{
    public const float firstMoveSpeed = 1f;
    public const float secondMoveSpeed = 2f;
    public const float thirdMoveSpeed = 4f;

    public static float GetMaximumSpeed
    {
        get
        {
            float returnValue = 0f;
            switch (GameConstant.gameLevel)
            {
                case GameLevel.first:
                    {
                        returnValue = firstMoveSpeed;
                    }
                    break;
                case GameLevel.second:
                    {
                        returnValue = secondMoveSpeed;
                    }
                    break;
                case GameLevel.third:
                    {
                        returnValue = thirdMoveSpeed;
                    }
                    break;
                 default:
                    {
                        returnValue = 1f;
                    }
                    break;
            }

            return returnValue;
        }
    }
}

public static class LevelData
{
    public const float firstRisingSpeed = 2.5f;
    public const float secondRisingSpeed = 3.5f;
    public const float thirdRisingSpeed = 4.0f;

    public const int firstMovePlatformProbability = 0;
    public const int secondMovePlatformProbability = 50;
    public const int thirdMovePlatformProbability = 100;

    public const float firstPitchValue = 1.05f;
    public const float secondPitchValue = 1.1f;
}

public static class ItemData
{
    public const float PowerJumpPower = 25f;
    public const int BrushPlatformMakeNum = 10;

}
public static class Probabilities
{
    public const float WingSpawnProbabiliy = 0.5f;
    public const float BrushSpawnProbability = 1f;
}

public static class LayerName
{
    public const string All = "All";
    public const string Red = "Red";
    public const string Green = "Green";
    public const string Blue = "Blue";
}

public static class PlayerPrefKeys
{
    public const string CharacterStyleKey = "CharacterStyle";
    public const string BgmVolumeKey = "BgmVolume";
    public const string EffectVolumeKey = "EffectVolume";
    public const string BgmMuteKey = "BgmMuteKey";
    public const string EffectMuteKey = "EffectMuteKey";
}

public static class DBFileName
{
    public const string CharacterDBName= "CharacterDB.db";
}
