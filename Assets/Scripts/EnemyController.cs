using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
            Destroy(other.gameObject);
    }
}
