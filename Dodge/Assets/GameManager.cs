using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject level;
    public GameObject[] bullerSpawner;
    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    private float surviveTime;
    
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        surviveTime += Time.deltaTime;

        if(surviveTime <5f && spawnCounter ==0)
        {
            bullerSpawner[spawnCounter].SetActive(true);
            spawnCounter++;
        }
        else if (surviveTime >= 5f && surviveTime<10f && spawnCounter == 1)
        {
            bullerSpawner[spawnCounter].SetActive(true);
            spawnCounter++;
        }
        else if (surviveTime >= 10f && surviveTime < 15f && spawnCounter == 2)
        {
            bullerSpawner[spawnCounter].SetActive(true);
            spawnCounter++;
        }
        else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
        {
            bullerSpawner[spawnCounter].SetActive(true);
            spawnCounter++;
        }
    }
}
