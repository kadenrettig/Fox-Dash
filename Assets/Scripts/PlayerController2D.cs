using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;

    [SerializeField]
    private float jumpForce = 4.0f;
    [SerializeField]
    private float gravityScale = 4.0f;
    [SerializeField]
    private float jumpTimer = 0.3f;

    private bool pressedJump = false;
    private bool releasedJump = false;
    
    private bool startTimer = false;
    private float timer;

    public bool isActive = false;
    public bool isGrounded = true;
    public bool isInvulnerable = false;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        timer = jumpTimer;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isActive && isGrounded) {
                pressedJump = true; 
                ani.SetBool("isGrounded", false);
            }

            // player becomes active after pressing space once
            isActive = true;
        }

        if (Input.GetKeyUp(KeyCode.Space)) 
            releasedJump = true;

        if (startTimer) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                releasedJump = true;
            }
        }

        if (isActive)
            ani.SetBool("isRunning", true);
    }

    /// <summary>
    /// Used for physics calculations. Seta  force to a Rigidbody and it applies 
    /// each fixed frame. Occurs at a measured time set that typically does not 
    /// coincide with MonoBehavior.Update().
    /// </summary>
    private void FixedUpdate() {
        if (pressedJump) {
            StartJump();
        }

        if (releasedJump) {
            StopJump();
        }
    }

    /// <summary>
    /// Begin adding force to the player, allowing them to jump.
    /// </summary>
    private void StartJump() {
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        pressedJump = false;
        startTimer = true;
    }

    /// <summary>
    /// Reset the application of force to allow falling after the jump key is 
    /// no longer being pressed.
    /// </summary>
    private void StopJump() {
        rb.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }

    /// <summary>
    /// Detects whether a GameObject with a Collider2D component enters 
    /// this gameObject.
    /// </summary>
    /// <param name="other">
    private void OnTriggerEnter2D(Collider2D other) {
        // ensure the player is touching the ground in order to jump
        if (other.tag == "Floor") {
            isGrounded = true;
            ani.SetBool("isGrounded", true);
        }
    }
}
