using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public float gameSpeed;
    public float delay;
    public float speedIncrement;

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
