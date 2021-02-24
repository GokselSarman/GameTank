using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{

    string movementAxis, turnAxis;
    float movementValue, turnValue;
    float moveSpeed, turnSpeed;
    public Rigidbody rb;

    void Start()
    {
        movementAxis = "Vertical";
        turnAxis = "Horizontal";
       
        moveSpeed = 5f;
        turnSpeed = 2000f;
        
    }

    private void FixedUpdate()
    {
        movementValue = Input.GetAxis(movementAxis);
        turnValue = Input.GetAxis(turnAxis);


        Move();
        Turn();
    }

    private void Turn()
    {
        float turn = turnValue * turnSpeed;
        Quaternion rot = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * rot);
    }

    private void Move()
    {
        Vector3 movePosition = transform.forward * movementValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movePosition);
    }
}
