using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnTrigger : MonoBehaviour
{
   public KeyCode triggerKey = KeyCode.Space;
    
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
      // if the trigger key is detected, set the object's state to inactive
      if (Input.GetKeyDown(triggerKey)) {
         Destroy(gameObject);
      }
    }
}
