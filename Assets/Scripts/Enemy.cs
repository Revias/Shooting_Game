using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    public GameObject explosionFactory;

    void Start()
    {

        int randValue = UnityEngine.Random.Range(0, 10);

        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            // 방향을 구하고 싶다.
            dir = target.transform.position - transform.position;
            // 방향의 크기를 1로 하고 싶다.
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {

        // 이동 공식  P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        // 폭팔 효과
        GameObject explosion = Instantiate(explosionFactory);
        // 폭팔 효과 위치
        explosion.transform.position = transform.position;

        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        gameObject.SetActive(false);
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        manager.enemyObjectPool.Add(gameObject);

        // 점수 갱신
        ScoreManager.Instance.Score++;
    }
}
