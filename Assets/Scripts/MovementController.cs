using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    string animationState = "AnimationState";

    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D rb2D;

    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

    private void Update()
    {
        UpdateState();    
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 벡터를 정규화하여 플레이어가 대각선, 수직, 수평, 어느 방향으로 움직이든 일정한 속력을 유지하도록 해준다.
        movement.Normalize();

        rb2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (movement.x > 0)
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        else if (movement.x < 0)
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        else if (movement.y < 0)
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        else if (movement.y > 0)
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        else
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
    }
}
