using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Now you crash into other cars, isn't it silly, wouldn't it make the creator a silly little guy (the creator is doing this at 3 am someone send help I am going crazy)
public class ONLYNOWITSNOLONGERASTRAIGHTROAD : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public GameObject triggerObject;
    public float minXPosition = 1.4f;
    public float maxXPosition = 956f;
    public float triggerXPosition = 956f;
    public float[] yPositions;
    public float minSpacing = 7.0f;
    public int minSpawnCount = 10;
    public int maxSpawnCount = 30;

    private bool respawnInProgress = false;

    private void Start()
    {
        RespawnObjects();
    }

    private void Update()
    {
        if (!respawnInProgress && triggerObject != null && triggerObject.transform.position.x >= triggerXPosition)
        {
            StartCoroutine(RespawnWithDelay());
        }
    }

    private IEnumerator RespawnWithDelay()
    {
        respawnInProgress = true;

        DeleteSpawnedObjects();

        yield return new WaitForSeconds(1.0f);

        RespawnObjects();

        respawnInProgress = false;
    }

    private void RespawnObjects()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

        float lastSpawnX = float.MinValue;

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject objectToInstantiate = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            float randomX;
            float randomY = yPositions[Random.Range(0, yPositions.Length)];

            do
            {
                randomX = Random.Range(minXPosition, maxXPosition);
            } while (Mathf.Abs(randomX - lastSpawnX) < minSpacing);

            lastSpawnX = randomX;

            Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z);

            GameObject spawnedObject = Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
            spawnedObject.tag = "SpawnedObject";
        }
    }

    private void DeleteSpawnedObjects()
    {
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");

        foreach (var spawnedObject in spawnedObjects)
        {
            Destroy(spawnedObject);
        }
    }
}