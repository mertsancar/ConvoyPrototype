using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] tilePreFabs;
    private float spawn_Z = 40.0f;
    private float safe_zone = 80.0f;
    private float tile_lenght = 110f;
    private int amount_tile_on_screen = 3;


    private Transform player_transform;

    private List<GameObject> active_tiles;


    void Start()
    {
        active_tiles = new List<GameObject>();
        player_transform = player.transform;

        for (int i = 0; i < amount_tile_on_screen; i++) 
        {

            //if (i < 3)
            //{
            //    SpawnTile(0);
            //}
            //else
            //{
            //    SpawnTile(Random.Range(1, 3));
            //}
            SpawnTile(i);


        }

    }

    void Update()
    {
        if (player_transform.position.z - safe_zone > (spawn_Z - amount_tile_on_screen * tile_lenght))
        {
            DeleteTile();
            SpawnTile(Random.Range(0, 3));
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
