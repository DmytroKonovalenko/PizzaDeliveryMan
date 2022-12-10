using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 6;
    [SerializeField] private Transform player;
    private int startTiles = 9;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startTiles; i++)
        {
            if (i == 0)
                SpawnTile(2);
            SpawnTile(Random.Range(0, tilePrefabs.Length));

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 0.6f > spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
        if(player.CompareTag("Exit"))
        {
            SpawnTile(2);
        }

    }
    private void SpawnTile(int tileIndex)
    {

        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
