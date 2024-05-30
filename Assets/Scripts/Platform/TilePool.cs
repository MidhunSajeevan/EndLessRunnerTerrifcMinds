using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    // Array of tile prefabs to be used for spawning tiles.
    public GameObject[] tilePrefabs;
    // List to keep track of available tiles that can be reused.
    private List<GameObject> availableTiles = new List<GameObject>();

    // Method to get a tile from the pool or create a new one if none are available.
    public GameObject GetTile(int prefabIndex)
    {
        GameObject tile = null;

        // Check if there are any available tiles in the pool.
        if (availableTiles.Count > 0)
        {
            // Get the first available tile.
            tile = availableTiles[0];
            // Remove it from the list of available tiles.
            availableTiles.RemoveAt(0);
        }
        else
        {
            // Instantiate a new tile if none are available.
            tile = Instantiate(tilePrefabs[prefabIndex]);
        }

        // Activate the tile before returning it.
        tile.SetActive(true);
        return tile;
    }

    // Method to return a tile to the pool for reuse.
    public void ReturnTile(GameObject tile)
    {
        // Deactivate the tile to prepare it for reuse.
        tile.SetActive(false);
        // Add the tile to the list of available tiles.
        availableTiles.Add(tile);
    }
}
