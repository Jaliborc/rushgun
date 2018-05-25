using UnityEngine;
using System.Collections;

public class Overlord : MonoBehaviour {
	public GameObject explosion;
	public AudioClip[] wounds;
	public AudioClip death;
	
	int life = 3;
	void Start() {
		explosion.SetActiveRecursively(false);
	}
	
	// Detects contacts
	void OnTriggerEnter(Collider collision) {
		GameObject gameObject = collision.gameObject;
		
		if (gameObject.name == "Bullet(Clone)") {
			Destroy(gameObject);
			life -= 1;
			
			// audio is played by animations
			if (life == 0) {
				Events.FireMonsterKilled(transform.parent);
				animation.CrossFade("Die", 0.2f);
				audio.clip = death;
			} else {
				audio.clip = wounds[Random.Range(0, wounds.Length)];
				animation.Blend("Hit", 0.2f);
			}
			
		} else if (gameObject.name == "Player") {
			Events.FireGameOver();
		}
	}
	
	// Called by "Die" animation
	void Explode() {
		explosion.SetActiveRecursively(true);
	}
	
	void Destroy() {
		Destroy(gameObject);
	}
}
