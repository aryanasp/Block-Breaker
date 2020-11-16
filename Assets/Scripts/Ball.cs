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
    [SerializeField]
    private AudioClip[] ballSounds;

    //cached component references
    private AudioSource myAudioSource;
    private Rigidbody2D myRigidbody2D;

    // state
    Vector2 paddleToBallVector;
    private bool hasStarted = false;
    private bool shouldLaunchBall = false;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (!hasStarted)
        {
            LockBallToPaddle();
        }
        if (shouldLaunchBall)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        shouldLaunchBall = false;
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
            shouldLaunchBall = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
