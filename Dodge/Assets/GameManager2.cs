using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager2 : MonoBehaviour
{
    public GameObject bullerSpawnerPrefab;
    public GameObject itemPrefab;
    public GameObject level;
    int prevTime;
    int spawnCounter = 0;
    private float surviveTime;
    private bool isGameover;

    int prevEventTime;
    List<GameObject> itemList = new List<GameObject>();
    List<GameObject> spawnerList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        prevTime = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            int currTime = (int)(surviveTime % 5f);
            if(currTime ==0&& prevTime != currTime)
            {
                Vector3 randposBullet = new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-8f, 8f));

                Vector3 randpos = new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-8f, 8f));
                GameObject item = Instantiate(itemPrefab, randpos, Quaternion.identity);
                item.transform.parent = level.transform;
                item.transform.localPosition = randpos;
                itemList.Add(item);
            }
            prevTime = currTime;
            int eventTime = (int)(surviveTime % 10f);
            if(eventTime ==0&&prevEventTime != eventTime)
            {
                foreach(GameObject item in itemList)
                {
                    Destroy(item);
                }
                itemList.Clear();
            }
            prevEventTime = eventTime;
        }
    }
}
