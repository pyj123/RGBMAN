using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtil
{
    /// <summary>
    /// 확률 결과 반환
    /// </summary>
    /// <param name="prob">0~100 Value income</param>
    /// <returns></returns>
    public static bool GetPercentageResult(int prob)
    {
        int randNum = Random.Range(0, 100);
        return prob>=randNum;
    }

    public static bool GetPercentageResult(float prob)
    {
        int randNum;
        if (prob < 1f)
        {
            prob = prob * 10f;
            randNum = Random.Range(0, 1000);
            return prob >= randNum;
        }

        randNum = Random.Range(0, 100);
        return prob >= randNum;

    }


}
