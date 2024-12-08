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
            isActive = true;
            if (isGrounded) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
                ani.SetBool("isGrounded", false);
            }
        }

        if (isActive)
            ani.SetBool("isRunning", true);
    }

    // Ensure the player is touching the ground in order to jump
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Floor") {
            isGrounded = true;
            ani.SetBool("isGrounded", true);
        }
    }
}
