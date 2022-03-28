using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] tilePreFabs;
    private float spawn_Z = 0.0f;
    private float safe_zone = 80.0f;
    private float tile_lenght = 110f;
    private int amount_tile_on_screen = 6;
    private int emptyWayCounter = 0;

    private Transform player_transform;

    private List<GameObject> active_tiles;


    void Start()
    {
        active_tiles = new List<GameObject>();
        player_transform = player.transform.GetChild(0).transform;

        SpawnTile(0);
        for (int i = 0; i < amount_tile_on_screen; i++) 
        {
            SpawnTile(i);
            //if(i == amount_tile_on_screen/2)
            //{
            //    SpawnTile(0);
            //    continue;
            //}
            //SpawnTile(Random.Range(1, tilePreFabs.Length - 1));

        }

    }

    void Update()
    {
        if (UIManager._instance.gameOverPanel.activeSelf || UIManager._instance.youWinPanel.activeSelf)
        {
            return;
        }
        if (player_transform.position.z - safe_zone > (spawn_Z - amount_tile_on_screen * tile_lenght))
        {
            DeleteTile();
            if (emptyWayCounter < 3)
            {
                SpawnTile(Random.Range(1, tilePreFabs.Length - 1));
            }
            else
            {
                SpawnTile(0);
                emptyWayCounter = 0;
            }
        }
    }

    private void SpawnTile(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(tilePreFabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawn_Z;
        spawn_Z += tile_lenght;
        active_tiles.Add(go);

    }

    private void DeleteTile()
    {
        Destroy(active_tiles[0]);
        active_tiles.RemoveAt(0);
    }
}
