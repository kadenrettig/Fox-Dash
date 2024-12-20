using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
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
    /// Detects whether a GameObject with a Collider2D component enters 
    /// this gameObject.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other) {
        // destroy the object that collided
        Destroy(other.gameObject);

        // if the obj that collided has a container, clean it up
        var parent = other.gameObject.transform.parent;
        if (parent && parent.tag != "GameController") 
            Destroy(other.gameObject.transform.parent.gameObject);
    }
}
