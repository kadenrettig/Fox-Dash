using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public static float gameSpeed = 4.0f;
    private float delay = 2;
    private float speedIncrement = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseGameSpeed", 4, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseGameSpeed() {
        gameSpeed += speedIncrement;
    }
}
