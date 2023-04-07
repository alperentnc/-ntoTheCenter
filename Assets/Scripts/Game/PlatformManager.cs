using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public float platformDistance = 2f;
    public float platformSpawnHeight = 0f;
    public int platformCount = 10;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platformCount; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (playerTransform.position.y < spawnedPlatforms[0].transform.position.y + platformDistance)
        {
            Destroy(spawnedPlatforms[0]);
            spawnedPlatforms.RemoveAt(4);
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject platform = Instantiate(platformPrefabs[randomIndex], transform);
        float xPosition = Random.Range(-2.5f, 2.1f);
        float yPosition = platformSpawnHeight + (spawnedPlatforms.Count * platformDistance);
        platform.transform.position = new Vector2(xPosition, yPosition);
        spawnedPlatforms.Add(platform);
    }
}
