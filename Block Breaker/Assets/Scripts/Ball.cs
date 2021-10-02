using UnityEngine;

public class Ball : MonoBehaviour {

    // Config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // Cached references
    AudioSource audioSource;
    Rigidbody2D rb2d;

    // State variables
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    private void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
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
            rb2d.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other) {

        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted) {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            rb2d.velocity += velocityTweak;
        }
    }
}
