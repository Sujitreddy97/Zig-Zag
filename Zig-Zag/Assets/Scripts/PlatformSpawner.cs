using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    Vector3 currPos;
    float size;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        currPos = platform.transform.position;
        size = platform.transform.localScale.x;
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatforms();
        }
    }
        
    public void StartSpawningPlatform()
    {
        InvokeRepeating("SpawnPlatforms", 0.5f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
        
    }
    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = currPos;
        pos.x += size;
        currPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int randNo = Random.Range(0, 4);
        
        if(randNo < 1)
        {
            Quaternion rot = Quaternion.Euler(0f, 90f, 45f);
            Instantiate(diamond, new Vector3(pos.x, pos.y + 2, pos.z),rot );
        }

    }

    void SpawnZ()
    {
        // currPos = platform.transform.position;
        //size = platform.transform.localScale.x;
        Vector3 pos = currPos;
        pos.z += size;
        currPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int randNo = Random.Range(0, 4);

        if (randNo < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 2, pos.z), diamond.transform.rotation);
        }

    }
}
