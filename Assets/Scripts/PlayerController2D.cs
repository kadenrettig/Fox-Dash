using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator ani;
    public float jumpForce = 7.0f;
    public bool isActive = false;
    public bool isGrounded = true;
    public bool isInvulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded && isActive) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
                ani.SetBool("isGrounded", false);
            }
            // player becomes active after pressing space once (to avoid silly jump)
            isActive = true;
        }

        

        if (isActive)
            ani.SetBool("isRunning", true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ensure the player is touching the ground in order to jump
        if (other.tag == "Floor") {
            isGrounded = true;
            ani.SetBool("isGrounded", true);
        }
    }
}
