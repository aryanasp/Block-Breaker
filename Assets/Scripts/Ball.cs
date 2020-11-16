using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField]
    private Paddle paddle;
    [SerializeField]
    private float xPush = 2f;
    [SerializeField]
    private float yPush = 15f;
    private Rigidbody2D myRigidbody2D;

    // state
    Vector2 paddleToBallVector;
    private bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        myRigidbody2D.velocity = new Vector2(xPush, yPush);
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = paddle.transform.position;
        transform.position = paddlePos + paddleToBallVector;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
        }
    }
}
