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

        // ���͸� ����ȭ�Ͽ� �÷��̾ �밢��, ����, ����, ��� �������� �����̵� ������ �ӷ��� �����ϵ��� ���ش�.
        movement.Normalize();

        rb2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (movement.x > 0)
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        else if (movement.x < 0)
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        else if (movement.y > 0)
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        else if (movement.y < 0)
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        else
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
    }
}
