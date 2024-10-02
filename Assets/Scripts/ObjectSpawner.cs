using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] gameObjects;
    public float delay = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 4, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject() 
    {
        // Decide which prefab will be spawned and set its location
            int p = Random.Range(0, gameObjects.Length-1);
            Vector3 spawnPosition = new Vector3(0, -4, 0);

            // Spawn the prefab and assign its parent
            GameObject newObject = Instantiate(gameObjects[p], spawnPosition, gameObjects[p].transform.rotation);
            newObject.transform.SetParent(gameObject.transform, true);
    }
}
