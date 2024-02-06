using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] FloatVariable lives;
    [SerializeField] Physics_CharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;

	private void Start() {
        health.value = 50;
        lives.value = 3;
	}

    private int score = 0;

    public int Score {
        get {
            return score;
        }
        set {
            score = value;
            scoreText.text = "Score: " + score.ToString();
            scoreEvent.raiseEvent(score);
        }
    }

	private void OnEnable() {
        gameStartEvent.subscribe(OnStartGame);
	}

	private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Finish") && GameManager.Instance.state == GameManager.State.PLAY_GAME) {
            GameManager.Instance.state = GameManager.State.GAME_OVER_WIN;
        }
    }

    public void addPoints(int points) {
        Score += points;
    }

    private void OnStartGame() {
        characterController.enabled = true;
    }

    public void applyDamage(float damage) {
        health.value -= damage;
        if (health.value <= 0) {
            playerDeadEvent.raiseEvent();
        }
    }

    public void OnRespawn(GameObject respawn) {
        if (lives.value > 0 ) {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset();
        lives.value = lives.value - 1;
        }
        else if (lives.value <= 0) {
            playerDeadEvent.raiseEvent();
        }
    }
}
