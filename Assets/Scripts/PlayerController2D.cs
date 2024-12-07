using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 7.0f;
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (isGrounded) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
            }

    }

    // Ensure the player is touching the ground in order to jump
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Floor")
            isGrounded = true;
    }
}
