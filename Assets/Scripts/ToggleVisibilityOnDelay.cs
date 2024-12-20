using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityOnDelay : MonoBehaviour
{
    private float timeDelay = 0.8f;
    private float repeatRate = 0.8f;
    
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        InvokeRepeating("ToggleVisibiliity", timeDelay, repeatRate);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Toggles the visibility of the gameObject.
    /// </summary>
    void ToggleVisibiliity() {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
