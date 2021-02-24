using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    string movementAxis, turnAxis;
    float movementValue, turnValue;
    float moveSpeed, turnSpeed;
    public Rigidbody rb;

    float turbo;
    void Start()
    {
        movementAxis = "Vertical1";
        turnAxis = "Horizontal1";
        

        moveSpeed = 15f;
        turnSpeed = 100f;
        turbo = 4f;

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
        float turn = turnValue * turnSpeed * Time.deltaTime;
        Quaternion rot = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * rot);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
           

            Vector3 movePosition = transform.forward * turbo * movementValue * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movePosition);
        }
        else {
            Vector3 movePosition = transform.forward * movementValue * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movePosition);
        }

        
    }
}
