using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    public GameObject p;
    public int damage = 30;
    // Start is called before the first frame update
    void Start()
    {

        p = GameObject.FindWithTag("Player");
        Vector3 a = ( p.transform.position- transform.position).normalized;
        Vector3 c = new Vector3(a.x, 0f, a.z);
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = c * speed;
       // Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.GetDamage(damage);
                Destroy(this.gameObject);
            }
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
