using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;
    public int poolSize = 10;

    public List<GameObject> bulletObjectPool;
    // 태어날 때 오브젝트 풀에 총알을 하나씩 생성해 넣고 싶다. 
    void Start()
    {
        // 탄창을  총알 담을 수 있는 크키로 만들어준다.
        bulletObjectPool = new List<GameObject>();

        // 탄창에 넣을 총알 개수만큼 반복해
        for (int i = 0; i < poolSize; i++)
        {
            // 총알 공장에서 총알을 생성
            GameObject bullet = Instantiate(bulletFactory);

            // 총알을 오브젝트 풀에 넣고 싶다.
            bulletObjectPool.Add(bullet);
            // 비활성화
            bullet.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자가 발사 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);

                bullet.transform.position = transform.position;
            }
        }
    }
}
