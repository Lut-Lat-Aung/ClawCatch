using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour


{
    // Start is called before the first frame update

    public GameObject[] ballPrefabs;


    private float spawnLimitXLeft = -2;
    private float spawnLimitXRight = 2;
    private float spawnPosY = 5;

    private float spawnCount = 7;

    //private float startDelay = 1.0f;
    private float spawnInterval = 7.0f;
    private float nextSpawnTime;

    public GameObject NextLevelPanel;
    public GameObject GameOverPanel;


    void Start()
    {

        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

        nextSpawnTime = Time.time + spawnInterval;

    }

    // Update is called once per frame
    void Update()
    {

        //SpawnRandomBall();

        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomBall();

            // Decrease spawnInterval each time, with a lower limit
            spawnInterval = Mathf.Max(2.0f, spawnInterval - 0.5f);

            nextSpawnTime = Time.time + spawnInterval;
        }


        if (spawnCount > 20)
        {
            GameOverPanel.SetActive(true);
        }


        if (spawnCount == 0)
        {
            NextLevelPanel.SetActive(true);
        }

    }

    public void DeductSpawnCount()
    {
        spawnCount--;

        //Debug.Log("SpawnCount is deducted now :" + spawnCount);

        
    }

    void SpawnRandomBall()
    {
        //if (spawnInterval != 0)
        //{
        //    spawnInterval--;

        //}

        spawnCount++;

        //Debug.Log("SpawnCount is added now :" + spawnCount);
        Debug.Log("spawn is faster now :" + spawnInterval);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);



        int ballIndex = Random.Range(0, ballPrefabs.Length);


        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}
