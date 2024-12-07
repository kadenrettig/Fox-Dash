using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    private float horizontalSpawnPos = 36.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(int p, Vector3 spawnPosition) 
    {
        // spawn the prefab and assign its parent to the spawner
        GameObject newObject = Instantiate(gameObjects[p], spawnPosition, gameObjects[p].transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other) {
        // ensure this object is allowed to trigger a tileset spawn
        if (other.tag != "TilesetTrigger")
            return;

        // decide which prefab will spawn
        int p = Random.Range(0, gameObjects.Length);
        Vector3 spawnPosition = new Vector3(horizontalSpawnPos, 0, 0);
        Spawn(p, spawnPosition);
    }
}
