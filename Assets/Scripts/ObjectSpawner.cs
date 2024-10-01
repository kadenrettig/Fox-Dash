using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float gameSpeed;
    public GameObject[] gameObjects;
    private Operator op;
    // Start is called before the first frame update
    void Start()
    {
        op = transform.parent.GetComponent<Operator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current speed of the game
        gameSpeed = op.gameSpeed;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 spawnPosition = new Vector3(0, -4, 0); 
            Instantiate(gameObjects[0], spawnPosition, gameObjects[0].transform.rotation);
        }
    }
}
