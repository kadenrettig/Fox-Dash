using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    private float horizontalSpawnPos = 36.5f;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Instantiates a new GameObject that represents a tile set from the 
    /// right side of the screen.
    /// </summary>
    /// <param name="p">The Integer corresponding the the GameObject in the 
    /// array of GameObjects</param>
    /// <param name="spawnPosition">The Vector3 representing the spawn position
    /// of the GameObject in 3D space</param>
    void Spawn(int p, Vector3 spawnPosition) 
    {
        // spawn the prefab
        GameObject newObject = Instantiate(gameObjects[p], spawnPosition, gameObjects[p].transform.rotation);
    }

    /// <summary>
    /// Detects whether a GameObject with a Collider2D component enters 
    /// this gameObject.
    /// </summary>
    /// <param name="other"></param>
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
