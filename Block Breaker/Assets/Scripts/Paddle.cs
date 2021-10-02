using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.25f;
    [SerializeField] float maxX = 14.75f;

    GameStatus gameStatus;
    Ball ball;

    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    private void Update() {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos() {
        if (gameStatus.IsAutoPlayEnabled()) {
            return ball.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
