using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	[SerializeField] GameObject titleUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timerUI;
	[SerializeField] GameObject gameOverUI;
	[SerializeField] GameObject deadUI;
	[SerializeField] GameObject winUI;

	[Header("Health")]
	[SerializeField] FloatVariable health;
	[SerializeField] FloatVariable lives;
	[SerializeField] TMP_Text livesText;

	[SerializeField] GameObject respawn;
	[SerializeField] GameObject player;
	[SerializeField] FloatVariable time;

	[Header("Events")]
	//[SerializeField] IntEvent scoreEvent;
	[SerializeField] VoidEvent gameStartEvent;
	[SerializeField] GameObjectEvent respawnEvent;

	public enum State {
		TITLE,
		START_GAME,
		PLAY_GAME,
		GAME_OVER,
		GAME_OVER_WIN,
		DEAD
	}
	public State state = State.TITLE;

	private void Start() {
		//scoreEvent.subscribe(onAddPoints);
		//time.value = 120;
	}

	private void Update() {
		switch (state) {
			case State.TITLE:
				titleUI.SetActive(true);
				deadUI.SetActive(false);
				Time.timeScale = 0;
                time.value = 120;
                lives.value = 3;
                Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
			case State.START_GAME:
                titleUI.SetActive(false);
                winUI.SetActive(false);
                deadUI.SetActive(false);
                gameOverUI.SetActive(false);
                Time.timeScale = 1;
                
                health.value = 100;
                Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				gameStartEvent.raiseEvent();
				state = State.PLAY_GAME;
				break;
			case State.PLAY_GAME:
				time.value = time.value - Time.deltaTime;
				if (time.value <= 0) {
					state = State.GAME_OVER;
				}
				break;
			case State.GAME_OVER:
				Time.timeScale = 0;
				gameOverUI.SetActive(true);
				break;
			case State.GAME_OVER_WIN:
				Time.timeScale = 0;
				winUI.SetActive(true);
				break;
			case State.DEAD:
				Time.timeScale = 0;
				deadUI.SetActive(true);
				health.value = 100;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.transform.position = respawn.transform.position;
                player.transform.rotation = respawn.transform.rotation;
                gameStartEvent.raiseEvent();
                break;
		}
        timerUI.text = string.Format("{0:F1}", time.value);
        livesText.text = "Lives: " + lives.value.ToString();
	}

	public void onStartGame() {
		state = State.START_GAME;
	}

	public void onPlayerDead() {
		if (lives.value <= 0) {
			state = State.GAME_OVER;
		} else {
			lives.value--;
			state = State.DEAD;
		}
    }

	public void onAddPoints(int points) {
		print(points);
	}
}