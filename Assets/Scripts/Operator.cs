using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public static float gameSpeed = 0f;
    private float gameStartSpeed = 3.5f;
    private float maxGameSpeed = 10.0f;
    private float timeDelay = 6f;
    private float repeatRate = 3f;
    private float speedIncrement = 0.5f;
    private bool isAtMaxSpeed = false;
    private bool isGameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // start the game when the corresponding key is pressed
        if (!isGameStarted)
            if (Input.GetKeyDown(KeyCode.Space))
                StartGame();

        // cap the maximum speed as the game continues 
        if (gameSpeed >= maxGameSpeed && !isAtMaxSpeed) {
            isAtMaxSpeed = true;
            CancelInvoke("IncreaseGameSpeed");
            Debug.Log("Reached maximum speed");
        }
    }

    void StartGame() {
        isGameStarted = true;
        gameSpeed = gameStartSpeed;
        InvokeRepeating("IncreaseGameSpeed", timeDelay, repeatRate);
    }

    void IncreaseGameSpeed() {
        gameSpeed += speedIncrement;
    }
}
