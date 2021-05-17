using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 mid;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
        mid = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(mid, Vector3.down, speed * Time.deltaTime);
    }
}
