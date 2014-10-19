using UnityEngine;
using System;
using System.Collections;

public class PlayerControlScript : MonoBehaviour 
{
    public PlayerState playerState;
    Transform playerTransform;
    Rigidbody2D playerRigidBody;

    //[NonSerialized]
    public float platformDelta = 0f;
    public float speed = 3f;

    Vector2 jumpVector;
    public float jumpForce;
    private float leftLimit;
    private float rightLimit;

    public ManageAnimations manageAnimations;

    private void Start()
    {
        playerTransform = this.transform;
        playerRigidBody = playerTransform.rigidbody2D;
        jumpVector = new Vector2(0f, jumpForce);
        playerState = PlayerState.Idle;
        manageAnimations = GetComponent<ManageAnimations>();

        InitScreenLimits();
    }

    private void FixedUpdate()
    {
        //clamp player 
        if (playerTransform.position.x >= rightLimit || playerTransform.position.x <= leftLimit)
        {
            playerTransform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, leftLimit, rightLimit), playerTransform.position.y, playerTransform.position.z);
        }
    }

    private void InitScreenLimits()
    {
        float distanceToPlayer = Vector3.Distance(Camera.main.transform.position, playerTransform.position);
        leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToPlayer)).x + 0.5f;
        rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToPlayer)).x - 0.5f;
    }

    public void MovePlayer(float value)
    {
        manageAnimations.PlayCharactherAnimation(PlayerAnimations.Running);
        playerRigidBody.velocity = new Vector2(value * speed + platformDelta, playerRigidBody.velocity.y);
    }

    public void Jump()
    {
        if ((playerState == PlayerState.Running || playerState == PlayerState.Idle) && rigidbody2D.velocity.y <= 0f)
        {
            playerRigidBody.AddForce(jumpVector, ForceMode2D.Impulse);
            playerState = PlayerState.Jumping;
            manageAnimations.PlayCharactherAnimation(PlayerAnimations.Idle,true,true);
        }
    }
}
