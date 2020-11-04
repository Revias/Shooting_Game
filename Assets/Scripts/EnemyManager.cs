using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int poolSize = 10;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;
    public float minTime = 0.5f;
    public float maxTime = 1.5f;

    // 현재 시간
    float currentTime;
    // 일정 시간
    public float createTime = 1;
    // 적 공장
    public GameObject enemyFactory;


    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        // 시간이 흐르다가 
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject enemy = enemyObjectPool[0];
            if (enemyObjectPool.Count > 0)
            {
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                
            }
            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
