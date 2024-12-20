using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Operator : MonoBehaviour
{
    //-------------------- OBJECTS --------------------//
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private TextMeshProUGUI scoreTextMesh;

    //-------------------- GAME SPEED --------------------//
    public static float gameSpeed = 0.0f;
    private static float gameStartSpeed = 6.5f;
    private static float maxGameSpeed = 20.0f;
    private static float speedIncrement = 0.5f;
    private bool isAtMaxSpeed = false;
    private float timeDelay = 6.0f;
    private float repeatRate = 3.0f;

    //-------------------- GAME SCORING --------------------//
    public int score = 0;
    public int bestScore = 0;

    //-------------------- GENERAL VARS --------------------//
    private KeyCode startGameInput = KeyCode.Space;
    private bool isGameStarted = false;
    private float gameStartTime;
    public float timeElapsed = 0.0f;

    //-------------------- PLAYER-SPECIFIC VARS --------------------//
    private bool isTrackingPlayer = false;

    /// <summary>
    /// Code runs before the first frame.
    /// </summary>
    void Start()
    {
        isTrackingPlayer = player != null;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // if the game hasn't yet been started, await the required input
        if (!isGameStarted) {
            if (Input.GetKeyDown(startGameInput))
                StartGame();
            return;
        }
        
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

        // calculate the player's score if the game has started
        CalculateScore();
    }

    /// <summary>
    /// Sets and resets game variables to prepare for the start of the game.
    /// </summary>
    void StartGame() {
        isGameStarted = true;
        gameSpeed = gameStartSpeed;
        score = 0;
        gameStartTime = Time.time;
        InvokeRepeating("IncreaseGameSpeed", timeDelay, repeatRate);
        
        Debug.Log("Game Started!!");
    }

    /// <summary>
    /// Sets and resets variables once the game has ended (Player has died).
    /// </summary>
    void EndGame() {
        isGameStarted = false;
        CancelInvoke("IncreaseGameSpeed");
        gameSpeed = 0f;
        bestScore = score > bestScore ? score : bestScore;

        Debug.Log("Game Ended!!");
    }

    /// <summary>
    /// Calculate the player's score using the elapsed time since the game was
    /// started.
    /// </summary>
    void CalculateScore() {
        timeElapsed = Time.time - gameStartTime;
        score = Convert.ToInt32(timeElapsed * gameSpeed);
        scoreTextMesh.text = Convert.ToString(score);
    }

    /// <summary>
    /// Increments the game's speed over time. Required for InvokeRepeating().
    /// </summary>
    void IncreaseGameSpeed() {
        gameSpeed += speedIncrement;
    }
}
