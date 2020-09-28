using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFSM : StateMachine
{

    private float horizontalMovement;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Vector3 velocity = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        PlayerState.idleState = new IdleState();
        PlayerState.runState = new RunState();

        SetState(PlayerState.idleState);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float horizontalMovement)
    {
        // Movement Horizontal
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        // Nuancier de saut
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


}
