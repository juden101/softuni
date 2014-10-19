using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnvironmentScript : MonoBehaviour 
{

    //platform Vars
    public float generatePlatformPeriod = 200f;
    private float periodCounter = 0f;
    private float minSpawnPositionY = -3.5f;
    private float maxSpawnPositionY = 3.5f;
    private float SpawnPositionX = 10f;
    public float minPlatformSpeed = 0.02f;
    public float maxPlatformSpeed = 0.08f;
    private float platformSpeed;
    public GameObject coinPrefab;
    float minPlatformDistance = 1.6f;
    Vector3 lastGeneratedPostion = Vector3.zero;
    private bool isGamePasued;

    public Transform playerTransform;
    private PlayerLogicScript playerLogicScript;

    private void Start()
    {
        if (playerTransform != null)
        {
            playerLogicScript = playerTransform.GetComponent<PlayerLogicScript>();
            playerLogicScript.pauseGame += EnvironmentScript_pauseGame;
        }
    }

    void EnvironmentScript_pauseGame()
    {
        isGamePasued = !isGamePasued;
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        UpdatePlatformGeneration();
	}

    private void UpdatePlatformGeneration()
    {
        if (isGamePasued)
        {
            return;
        }

        periodCounter += Time.fixedDeltaTime;

        if (periodCounter < generatePlatformPeriod)
        {
            return;
        }

        //Debug.Log(string.Format("Generate : {0} max {1} ", periodCounter, generatePlatformPeriod));
        periodCounter = 0f;

        //Generate random position on the Y axis.X position is const positioned out side right part of the screen
        float positionY = 0f;
        positionY = UnityEngine.Random.Range(minSpawnPositionY, maxSpawnPositionY);
        Vector3 platformPosition = new Vector3(SpawnPositionX, positionY);

        float distanceFromPrevious = Vector3.Distance(lastGeneratedPostion,platformPosition);

        if (lastGeneratedPostion != Vector3.zero && distanceFromPrevious != 0f && distanceFromPrevious < minPlatformDistance)
        {
            do
            {
                positionY = UnityEngine.Random.Range(minSpawnPositionY, maxSpawnPositionY);
                platformPosition = new Vector3(SpawnPositionX, positionY);
                distanceFromPrevious = Vector3.Distance(lastGeneratedPostion,platformPosition);
            }
            while (distanceFromPrevious < minPlatformDistance);
        }

        lastGeneratedPostion = platformPosition;

        Transform platform = GetPlatform();
        if (platform == null)
        {
            return;
        }

        platform.position = platformPosition;

        PlatformScript platformScript = platform.GetComponent<PlatformScript>();
        platformScript.speed = UnityEngine.Random.Range(minPlatformSpeed, maxPlatformSpeed);
        platformScript.isMoving = true;
        platformScript.GenerateCoins(coinPrefab);
        platformScript.playerTransform = playerTransform;
        playerLogicScript.pauseGame += platformScript.PauseGame;

        periodCounter = 0f;
    }

    private Transform GetPlatform()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/smallPlatform");
        if (prefab == null)
        {
            Debug.Log("Unable to load prefab");
            return null;
        }

        Vector3 outSidePosition = new Vector3(-5f, -5f, 0f);
        GameObject newPlatform = GameObject.Instantiate(prefab, outSidePosition, Quaternion.identity) as GameObject;
        if (newPlatform == null)
        {
            Debug.Log("Unable to instantiate prefab");
            return null;
        }

        return newPlatform.transform;
    }


}
