using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs; // Array of platform prefabs to spawn
    public Transform characterTransform; // Reference to the transform of the main character
    public float platformSpawnDistance = 20f; // Distance from the character at which a new platform should be spawned
    public int maxPlatformCount = 10; // Maximum number of platforms that can exist at any given time
    public string leftPlatformTag = "LeftPlatform"; // Tag for left-aligned platforms
    public string rightPlatformTag = "RightPlatform"; // Tag for right-aligned platforms
    public string middlePlatformTag = "MiddlePlatform"; // Tag for middle-aligned platforms

    private List<GameObject> spawnedPlatforms = new List<GameObject>(); // List of all currently spawned platforms

    private void Start()
    {
        // Spawn initial platforms
        for (int i = 0; i < maxPlatformCount; i++)
        {
            
            SpawnPlatform();
        }
    }

    private void Update()
    {
        // Check if the last platform in the list is too far from the character
        if (spawnedPlatforms.Count > 0 && -spawnedPlatforms[0].transform.position.y < -characterTransform.position.y - platformSpawnDistance)
        {

            // Remove the last platform from the list and destroy it
            Destroy(spawnedPlatforms[0]);
            spawnedPlatforms.RemoveAt(0);
            // Spawn a new platform at the end
            SpawnPlatform();
            
        }
    }

    private void SpawnPlatform()
    {
        // Randomly select a platform prefab
        int platformIndex = Random.Range(0, platformPrefabs.Length);
        GameObject platformPrefab = platformPrefabs[platformIndex];

        // Instantiate the platform
        GameObject newPlatform = Instantiate(platformPrefab, transform);

        // Position the platform randomly
        Vector3 platformPosition = new Vector3(Random.Range(-2f, 2f), 3.75f, 0f);

        // Align the platform based on its tag
        if (newPlatform.CompareTag(leftPlatformTag))
        {
            platformPosition.x = -1.875f;
        }
        if (newPlatform.CompareTag(rightPlatformTag))
        {
            platformPosition.x = 1.54f;
        }
        if (newPlatform.CompareTag(middlePlatformTag))
        {
            platformPosition.x = Random.Range(-2f, 1.2f);
        }
        
        // Position the platform relative to the last platform in the list (if there is one)
        if (spawnedPlatforms.Count > 0)
        {
            Transform lastPlatformTransform = spawnedPlatforms[spawnedPlatforms.Count - 1].transform;
            platformPosition.y = lastPlatformTransform.position.y - lastPlatformTransform.localScale.y * 0.5f - 1.25f;
        }

        newPlatform.transform.localPosition = platformPosition;

        // Add the platform to the list of spawned platforms
        spawnedPlatforms.Add(newPlatform);
    }
}
