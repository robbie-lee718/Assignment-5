using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public Transform[] chunkPrefabs;

    public int initialChunks = 5;
    public float spawnAheadDistance = 18f;
    public float chunkLength = 6f;
    public Transform player;

    private readonly List<Transform> activeChunks = new List<Transform>();
    private float nextSpawnZ;

    private void Start()
    {
        if (chunkPrefabs == null || chunkPrefabs.Length == 0)
        {
            Debug.LogError("WorldGeneration requires at least one chunk prefab.");
            enabled = false;
            return;
        }

        if (player == null)
        {
            Debug.LogError("WorldGeneration requires a player transform reference.");
            enabled = false;
            return;
        }

        nextSpawnZ = 0f;
        for (int i = 0; i < initialChunks; i++)
        {
            SpawnChunk(i == 0 ? 0 : Random.Range(0, chunkPrefabs.Length));
        }
    }

    private void Update()
    {
        if (player.position.z + spawnAheadDistance > nextSpawnZ)
        {
            SpawnChunk(Random.Range(0, chunkPrefabs.Length));
            RemoveOldChunkIfNeeded();
        }
    }

    private void SpawnChunk(int prefabIndex)
    {
        Transform prefab = chunkPrefabs[prefabIndex];
        Transform chunkInstance = Instantiate(prefab, transform);
        chunkInstance.position = new Vector3(0f, 0f, nextSpawnZ);
        activeChunks.Add(chunkInstance);
        nextSpawnZ += chunkLength;
    }

    private void RemoveOldChunkIfNeeded()
    {
        if (activeChunks.Count <= initialChunks)
            return;

        Transform oldChunk = activeChunks[0];
        activeChunks.RemoveAt(0);
        Destroy(oldChunk.gameObject);
    }
}
