using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {
	public GUISkin indicators;
	public GUISkin alerts;
	public Texture aim;
	
	string scoreText = "Score: 0";
	string bulletsText = "Bullets: 30";
	int score = 0;
	bool gameOver;
	
	// Game Events
	void Start() {
		Events.GameOver += GameOver;
		Events.MonsterKilled += MonsterKilled;
		Events.BulletsChanged += BulletsChanged;
		Events.BulletMissed += BulletMissed;
	}
	
	void GameOver() {
		Time.timeScale = 0;
		gameOver = true;
	}
	
	void MonsterKilled(Transform monster) {
		score += 50;
		UpdateScore();
	}
	
	void BulletMissed() {
		if (score > 0) {
			score -= 1;
			UpdateScore();
		}
	}
	
	void BulletsChanged(int bullets) {
		bulletsText = "Bullets: " + bullets.ToString();
	}
	
	// Updates
	void Update () {
		if (!gameOver) {
			float y = Input.mousePosition.x / Screen.width * 125 + 120;
			float x = -Input.mousePosition.y / Screen.height * 60 + 30;
		
			Camera.main.transform.eulerAngles = new Vector3(x, y, 0);
		}
	}
	
	void UpdateScore() {
		scoreText = "Score: " + score.ToString(); // better convert on change than every frame
	}
	
	void OnGUI() {
		// Unity has one of the worst GUI frameworks I ever had the pleasure to work with
		int bottom = Screen.height - 50;
		int centerX = Screen.width / 2;
		int centerY = Screen.height / 2;
		
		GUI.Label (new Rect (13, bottom, 200, 100), scoreText, indicators.label);
		GUI.Label (new Rect (Screen.width - 140, bottom, 200, 100), bulletsText, indicators.label);
		
		if (!gameOver) {
			// This was making the game too easy
			//GUI.DrawTexture(new Rect (centerX - 5, centerY - 2, 24, 24), aim);
		} else {
			GUI.Label(new Rect (centerX - 250, centerY - 75, 500, 100), "Game Over", alerts.label);
			if (GUI.Button(new Rect (centerX - 110, centerY + 25, 220, 40), "Let's die again!", alerts.button)) {
				
				Time.timeScale = 1;
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
