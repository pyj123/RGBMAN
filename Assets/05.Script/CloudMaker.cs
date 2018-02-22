using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMaker : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosit1;

    [SerializeField]
    private Transform spawnPosit2;

    [SerializeField]
    private Cloud CloudPrefab;

    private ObjectPool<Cloud> cloudPool;

    private WaitForSeconds ws;

    [SerializeField]
    private float delay = 1f;

    [SerializeField]
    private float cloudSpeedMin = 1f;

    [SerializeField]
    private float cloudSpeedMax = 1f;

    [SerializeField]
    private float cloudLifeTime = 3f;

    private void Awake()
    {
        cloudPool = new ObjectPool<Cloud>(CloudPrefab, 10, this.transform);
        ws = new WaitForSeconds(delay);
    }

    private void Start()
    {
        StartCoroutine(MakeCloud());    
    }


    private IEnumerator MakeCloud()
    {
        Vector3 spawnPosit = Vector3.zero;
        float cloudSpeed;
        while (true)
        {
            Cloud cloud = cloudPool.GetItem();
            if (cloud != null)
            {
                cloudSpeed = Random.Range(cloudSpeedMin, cloudSpeedMax);
                spawnPosit = new Vector3(Random.Range(spawnPosit1.position.x, spawnPosit2.position.x), spawnPosit1.position.y, 0f);
                cloud.Initialize(spawnPosit, cloudSpeed, cloudLifeTime);
            }
            yield return ws;

            cloud = cloudPool.GetItem();
            if (cloud != null)
            {
                cloudSpeed = Random.Range(cloudSpeedMin, cloudSpeedMax);
                spawnPosit = new Vector3(Random.Range(spawnPosit1.position.x, spawnPosit2.position.x), spawnPosit1.position.y, 0f);
                cloud.Initialize(spawnPosit, cloudSpeed, cloudLifeTime);
            }

            yield return ws;

        }
    }

}
