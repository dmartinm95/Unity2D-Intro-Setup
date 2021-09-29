using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    AudioSource audioSource;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    private void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {

        if (!hasStarted) {
            LaunchOnMouseClick();
            LockBallToPaddle();
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (hasStarted) {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
