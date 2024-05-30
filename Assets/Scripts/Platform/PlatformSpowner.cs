using System.Collections.Generic;
using UnityEngine;

public class PlatformSpowner : MonoBehaviour
{
    public TilePool tilePool;
    private Transform playerTransform;
    private float spawnZ = -18.0f;
    private float safeZone = 20f;
    private float tileLength = 18f;
    private int amtTilesOnScreen = 20;
    private List<GameObject> activeTiles;
    private int lastPrefabIndex = 0;

    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amtTilesOnScreen; i++)
        {
            if(i == 0)
            {
                SpawnTile(0);
                activeTiles.RemoveAt(0);
            }
               
            if (i > 0 && i < 15)
                SpawnTile(1);
            else
                SpawnTile();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amtTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        int index = prefabIndex == -1 ? RandomPrefabIndex() : prefabIndex;
        GameObject go = tilePool.GetTile(index);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        tilePool.ReturnTile(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePool.tilePrefabs.Length <= 1)
            return 1;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(1, tilePool.tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
