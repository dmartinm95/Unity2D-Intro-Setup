using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    Vector2 paddleToBallVector;

    private void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    private void Update() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        transform.position = paddlePos + paddleToBallVector;
    }
}
