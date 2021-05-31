using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    public int damage = 30;
    public GameObject HitEffact;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 c = new Vector3(this.transform.forward.x, 0f, this.transform.forward.z);
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = c * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if(bullet!= null)
            {
                GameObject hit = Instantiate(HitEffact, transform.position, transform.rotation);
                Destroy(hit, 1);
                Destroy(bullet.gameObject);
            }
            Destroy(gameObject);
        }
        else if(other.CompareTag("BulletSpawner"))
        {
            BulletSpawner spawner = other.GetComponent<BulletSpawner>();
            Debug.Log(spawner.name);
            if (spawner != null)
            {
                GameObject hit = Instantiate(HitEffact, transform.position, transform.rotation);
                Destroy(hit, 1);
                spawner.GetDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            GameObject hit = Instantiate(HitEffact, transform.position, transform.rotation);
            Destroy(hit, 1);
            Destroy(this.gameObject);
        }
    }
}
