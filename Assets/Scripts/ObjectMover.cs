using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the movement speed to be the same as the game
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
}
