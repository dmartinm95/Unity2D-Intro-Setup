using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    Level level;
    GameStatus gameStatus;

    private void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        if (tag == "Breakable") {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (tag == "Breakable") {
            DestroyBlock();
        }
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
