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
        Destroy(other.gameObject);
        if (other.gameObject.transform.parent) {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
