using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 만약 부딪힌 물체가 buulet이라면
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            // 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);

            // 부딪힌 물체가 총알일 경우 총알 리스트에 삽입
            if (other.gameObject.name.Contains("Bullet"))
            {
                // PlayerFire 클래스 얻어오기
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                player.bulletObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
