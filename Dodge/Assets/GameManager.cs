using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject itemPrefab;
    float prevItemChecj;
    float prevItemTime;
    public GameObject level;
    public GameObject[] bullerSpawner;
    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    private float surviveTime;
    
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        prevItemTime = 0;
        prevItemChecj = 3;
    }

    // Update is called once per frame
    void Update()
    {
        surviveTime += Time.deltaTime;
        prevItemTime += Time.deltaTime;
        Vector3 randpos = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-8f, 8f));

        if (prevItemTime >=prevItemChecj)
        {
            prevItemTime = 0;
            GameObject item = Instantiate(itemPrefab, randpos, Quaternion.identity);
        }
        if (surviveTime <5f && spawnCounter ==0)
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
