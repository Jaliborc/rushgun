using UnityEngine;
using System.Collections;

public class Glock : MonoBehaviour {
	public GameObject bulletPrefab;
	public AudioClip noAmmo;
	public AudioClip reload;
	public AudioClip shot;
	
	float readyTime = 0;
	int bullets = 30;
	bool reloading;
	
	void Update () {
		bool ready = Time.time > readyTime;
		
		if (!reloading) {
			if (Input.GetButton("Fire") && ready) {
				readyTime = Time.time + .8f;
				
				if (bullets > 0) {
					// The prefab was placed in the barrel, so there's no need to calculate initial position
					Transform origin = bulletPrefab.transform;
					GameObject bullet = Instantiate(bulletPrefab, origin.position, origin.rotation) as GameObject;
					bullet.rigidbody.velocity = -origin.forward * 300;
					bullet.collider.isTrigger = false;
					
					bullets -= 1;
					Events.FireBulletsChanged(bullets);
					
					audio.clip = shot;
					audio.Play();
				} else {
					audio.clip = noAmmo;
					audio.Play();
				}
				
			} else if (Input.GetButton("Reload") && bullets < 30) {
				readyTime = Time.time + 3f;
				reloading = true;
				
				audio.clip = reload;
				audio.Play();
			}

		} else if (ready) {
			bullets = 30;
			reloading = false;
			Events.FireBulletsChanged(bullets);
		}
	}
}
