using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private List<T> datas;
    public List<T> Datas
    {
        get
        {
            return datas;
        }
    }

    private T prefab;

    private Transform parent;

    public ObjectPool(T prefab,int InitNum,Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
        datas = new List<T>();
        MakePool(InitNum);    
    }

    private void MakePool(int InitNum)
    {
        for (int i = 0; i < InitNum; i++)
        {
            MakeItem();
        }
    }

    public T GetItem()
    {
        if (datas == null) return null;
    
        if (datas.Count > 0)
        {
            for(int i = 0; i < datas.Count; i++)
            {
                if (datas[i].gameObject.activeSelf == true) continue;
                else
                {                    
                    datas[i].gameObject.SetActive(true);
                    return datas[i];
                }
            }    
        }

        T item = MakeItem();
        item.gameObject.SetActive(true);

        return item;
       
    }
       
 
    private T MakeItem()
    {
        if (prefab == null) return null;
        GameObject makeObj = GameObject.Instantiate(prefab.gameObject,parent);
        if (makeObj != null)
        {
            T data = makeObj.GetComponent<T>();
            data.gameObject.SetActive(false);
            datas.Add(data);
            return data;
        }

        return null;
    }



}
