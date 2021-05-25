using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int healAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f, 15f * Time.deltaTime, 0f);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.GetHeal(healAmount);
                Destroy(this.gameObject);
            }
        }
    }
}
