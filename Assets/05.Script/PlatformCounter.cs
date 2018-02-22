using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCounter : MonoBehaviour
{
    private Dictionary<RGBType, CountingData> platformData;

    private class CountingData
    {
        private int count=0;
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void AddCount()
        {
            count++;
        }
    }

    private void Awake()
    {
        platformData = new Dictionary<RGBType, CountingData>();
        SetDic();

    }

    private void SetDic()
    {
        if (platformData == null) return;
        for(int i=1;i< (int)RGBType.End; i++)
        {
            platformData.Add((RGBType)i, new CountingData());
        }
    }

    public void CountPlatform(RGBType type)
    {
        if (platformData == null) return;
        if (platformData.ContainsKey(type) == false) return;
        platformData[type].AddCount();
    }
    //업적에 전송
    public void ReportPlatformData()
    {
        foreach(KeyValuePair<RGBType,CountingData> data in platformData)
        {
            GoogleService.Instance.ReportSocialPlatformData(data.Key, data.Value.Count);
        }

        
    }
   
}
