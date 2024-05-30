using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Reference to the TilePool script that manages tile prefabs.
    public TilePool tilePool;
    // Player's transform to track their position.
    private Transform playerTransform;
    // Z position where the next tile should be spawned.
    private float spawnZ = -18.0f;
    // Safe zone distance before new tiles are spawned.
    private float safeZone = 30f;
    // Length of each tile.
    private float tileLength = 18f;
    // Number of tiles that should be on screen at any given time.
    private int amtTilesOnScreen = 20;
    // List to keep track of active tiles in the scene.
    private List<GameObject> activeTiles;
    // Index of the last prefab used to avoid repetition.
    private int lastPrefabIndex = 0;

    // Start is called before the first frame update.
    void Start()
    {
        // Initialize the active tiles list.
        activeTiles = new List<GameObject>();
        // Find the player's transform using the "Player" tag.
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Spawn the initial set of tiles.
        for (int i = 0; i < amtTilesOnScreen; i++)
        {
            // Spawn the first tile at a specific index.
            if (i == 0)
            {
                SpawnTile(0);
                // Remove the first tile from the list to avoid duplication.
                activeTiles.RemoveAt(0);
            }
            // Spawn tiles of type 1 for the first 14 tiles.
            if (i > 0 && i < 15)
                SpawnTile(1);
            else
                // Spawn random tiles for the rest.
                SpawnTile();
        }
    }

    // Update is called once per frame.
    void Update()
    {
        // Check if the player has moved past the safe zone, triggering new tile spawn and old tile deletion.
        if (playerTransform.position.z - safeZone > (spawnZ - amtTilesOnScreen * tileLength))
        {
            // Spawn a new tile.
            SpawnTile();
            // Delete the oldest tile.
            DeleteTile();
        }
    }

    // Method to spawn a new tile.
    private void SpawnTile(int prefabIndex = -1)
    {
        // If no index is specified, get a random prefab index.
        int index = prefabIndex == -1 ? RandomPrefabIndex() : prefabIndex;
        // Get a tile from the tile pool.
        GameObject go = tilePool.GetTile(index);
        // Set the tile's parent to the current transform.
        go.transform.SetParent(transform);
        // Position the tile correctly in the scene.
        go.transform.position = Vector3.forward * spawnZ;
        // Update the spawnZ for the next tile.
        spawnZ += tileLength;
        // Add the tile to the list of active tiles.
        activeTiles.Add(go);
    }

    // Method to delete the oldest tile.
    private void DeleteTile()
    {
        // Return the oldest tile to the tile pool.
        tilePool.ReturnTile(activeTiles[0]);
        // Remove it from the active tiles list.
        activeTiles.RemoveAt(0);
    }

    // Method to get a random prefab index.
    private int RandomPrefabIndex()
    {
        // If there is only one tile type, return 1.
        if (tilePool.tilePrefabs.Length <= 1)
            return 1;

        int randomIndex = lastPrefabIndex;
        // Ensure the new index is different from the last one.
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(1, tilePool.tilePrefabs.Length);
        }
        // Update the last prefab index.
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
