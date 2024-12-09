using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        // destroy the object that collided
        Destroy(other.gameObject);

        // if the obj that collided has a container, clean it up
        var parent = other.gameObject.transform.parent;
        if (parent && parent.tag != "GameController") 
            Destroy(other.gameObject.transform.parent.gameObject);
    }
}
