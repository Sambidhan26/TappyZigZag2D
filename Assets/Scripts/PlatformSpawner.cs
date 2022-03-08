using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject platformVaccume;
    public GameObject coinsPrefabs;

    Vector3 lastPosition;
    float size;

    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

        //InvokeRepeating("SpawnPlatforms", 2.0f, 0.2f);

        //for (int j = 0; j < 5; j++)
        //{
        //    SpawnZ();
        //}
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 2.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnX()
    {

        //temp value assigning on the vector
        Vector3 position = lastPosition;
        position.x += size;

        //reassigning to lastPosition
        lastPosition = position;


        Instantiate(platform, position, Quaternion.identity);

        int rand = Random.Range(0, 4);

        if (rand < 1)
        {
            Instantiate(coinsPrefabs, new Vector3(position.x, position.y + 4, position.z), coinsPrefabs.transform.rotation);
        }

    }

    void SpawnZ()
    {
        //temp value assigning on the vector
        Vector3 position = lastPosition;
        position.z += size;

        //reassigning to lastPosition
        lastPosition = position;

        Instantiate(platform, position, Quaternion.identity);
        int rand = Random.Range(0, 4);

        if (rand < 1)
        {
            Instantiate(coinsPrefabs, new Vector3(position.x, position.y + 4, position.z), coinsPrefabs.transform.rotation);
        }

    }

    void SpawnVaccume()
    {
        Vector3 position = lastPosition;
        //position.x += size;
        position.z += size;

        lastPosition = position;

        Instantiate(platformVaccume, position, Quaternion.identity);
    }

    void SpawnPlatforms()
    {
        if(gameOver)
        {
            return;
        }
        int rand = Random.Range(0, 6);
        if(rand == 5)
        {
            SpawnVaccume();
        }

        if (rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }
}
    