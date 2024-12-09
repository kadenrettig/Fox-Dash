using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public GameObject player;
    public static float gameSpeed = 0f;
    private static float gameStartSpeed = 6.5f;
    private static float maxGameSpeed = 20f;
    private static float speedIncrement = 0.5f;
    private float timeDelay = 6f;
    private float repeatRate = 3f;
    private bool isAtMaxSpeed = false;
    private bool isGameStarted = false;
    private bool isTrackingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        if (player)
            isTrackingPlayer = true;
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

        // check if the player has died, if they exist
        if (isTrackingPlayer) {
            if (player == null) {
                Debug.Log("Player has died.");
                EndGame();
            }
        }
    }

    void StartGame() {
        isGameStarted = true;
        gameSpeed = gameStartSpeed;
        InvokeRepeating("IncreaseGameSpeed", timeDelay, repeatRate);
    }

    void EndGame() {
        isGameStarted = false;
        CancelInvoke("IncreaseGameSpeed");
        gameSpeed = 0f;
        Debug.Log("Game Ended!!");
    }

    void IncreaseGameSpeed() {
        gameSpeed += speedIncrement;
    }
}
