using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnTrigger : MonoBehaviour
{
   public KeyCode triggerKey = KeyCode.Space;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // if the trigger key is detected, set the object's state to inactive
      if (Input.GetKeyDown(triggerKey)) {
         Destroy(gameObject);
      }
    }
}
