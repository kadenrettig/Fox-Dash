using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public static float gameSpeed = 2.0f;
    private float delay = 3;
    private float speedIncrement = 0.5f;

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
