using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 현재 시간
    float currentTime;
    // 일정 시간
    public float createTime = 1;
    // 적 공장
    public GameObject enemyFactory;

    float minTime = 1;
    float maxTine = 5;

    void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTine);
    }

    void Update()
    {
        // 시간이 흐르다가 
        currentTime += Time.deltaTime;

        // 만약 현재 시간이 일정 시간이 되면
        if (currentTime > createTime)
        {
            // 적 공장에서 적을 생성
            GameObject enemy = Instantiate(enemyFactory);
            // 내위에 갖다 놓고 싶다.
            enemy.transform.position = transform.position;

            currentTime = 0;

            createTime = UnityEngine.Random.Range(minTime, maxTine);
        }
    }
}
