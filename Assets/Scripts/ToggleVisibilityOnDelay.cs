using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityOnDelay : MonoBehaviour
{
    private float timeDelay = 0.8f;
    private float repeatRate = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ToggleVisibiliity", timeDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ToggleVisibiliity() {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
