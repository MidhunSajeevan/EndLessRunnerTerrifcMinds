using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> availableTiles = new List<GameObject>();

   

    public GameObject GetTile(int prefabIndex)
    {
        GameObject tile = null;
        if (availableTiles.Count > 0)
        {
            tile = availableTiles[0];
            availableTiles.RemoveAt(0);
        }
        else
        {
            tile = Instantiate(tilePrefabs[prefabIndex]);
        }

        tile.SetActive(true);
        return tile;
    }

    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        availableTiles.Add(tile);
    }
}
