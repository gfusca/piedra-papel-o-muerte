using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private Animator animator;
    private Vector2 movement;
    float speed = 3f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0) {
            animator.SetBool("walking", true);
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        } else {
            animator.SetBool("walking", false);
        }
    }

    void FixedUpdate() {
        // Movement
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
