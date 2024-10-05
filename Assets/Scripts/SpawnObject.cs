using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] gameObjects;

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
        //newObject.transform.SetParent(gameObject.transform, true);
    }

    void OnTriggerEnter2D(Collider2D other) {
        // ensure this object is allowed to trigger a tileset spawn
        if (other.tag != "TilesetTrigger") {
            return;
        }
        Debug.Log("Spawning new tileset");

        // decide which prefab will spawn
        int p = Random.Range(0, gameObjects.Length-1);
        Vector3 spawnPosition = new Vector3(49.5f, 0, 0);
        Spawn(p, spawnPosition);
    }
}
