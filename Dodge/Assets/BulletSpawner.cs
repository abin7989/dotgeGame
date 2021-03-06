using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;
    public float speed;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    private Vector3 mid;
    public int hp = 100;
    public MonsterHpBar hpbar;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        mid = Vector3.zero;
        target = FindObjectOfType<Player>().transform;
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= spawnRate)
        {

            timeAfterSpawn = 0f;
            GameObject bullet
                 = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        //transform.RotateAround(mid, Vector3.down, speed * Time.deltaTime);
    }
    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
