using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField]
    private Transform objectParent;

    [SerializeField]
    private SparkEffect sparkPrefab;

    [SerializeField]
    private DropItem dropItemPrefab;


    private ObjectPool<SparkEffect> sparkPool;
    private ObjectPool<DropItem> dropItemPool;



    private void Awake()
    {
        MakePool();
    }

    private void MakePool()
    {
        sparkPool = new ObjectPool<SparkEffect>(sparkPrefab, 5, objectParent);
        dropItemPool = new ObjectPool<DropItem>(dropItemPrefab, 3, objectParent);


    }

    public SparkEffect GetSparkEffect()
    {
        if (sparkPool == null) return null;
        return sparkPool.GetItem();
    }

    public void SpawnDropItem(DropItemType dropItemType,Transform targetPlatform,RGBType rgbType= RGBType.End)
    {
        if (dropItemPool == null) return;
        DropItem item = dropItemPool.GetItem();
        if (item != null)
        {
            item.Initialize(targetPlatform, dropItemType, rgbType);
        }

#if UNITY_EDITOR
        Debug.Log("DropItem생성");
#endif
    }
   

   

}
