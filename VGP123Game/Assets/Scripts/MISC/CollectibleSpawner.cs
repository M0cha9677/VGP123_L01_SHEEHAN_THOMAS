using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [Header("Collectible Prefabs")]
    [SerializeField] private List<GameObject> collectiblePrefabs = new();

    [Header("Spawn Points (Must be 5)")]
    [SerializeField] private List<Transform> spawnPoints = new();

    private void Start()
    {
        SpawnCollectibles();
    }

    private void SpawnCollectibles()
    {
        if (collectiblePrefabs.Count == 0)
        {
            Debug.LogError("No collectible prefabs assigned.");
            return;
        }

        if (spawnPoints.Count != 5)
        {
            Debug.LogError("You must assign exactly 5 spawn points.");
            return;
        }

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int randomIndex = Random.Range(0, collectiblePrefabs.Count);

            Instantiate(
                collectiblePrefabs[randomIndex],
                spawnPoints[i].position,
                Quaternion.identity
            );
        }
    }
}
