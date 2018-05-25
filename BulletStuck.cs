using UnityEngine;
using System.Collections;

public class BulletStuck : MonoBehaviour {
	public GameObject particlePrefab; // the effect will vary depending on the type of the object (e.g: metal, wood)
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Bullet(Clone)") {
			if (particlePrefab) {
				foreach (ContactPoint contact in collision.contacts) {
					Instantiate(particlePrefab, contact.point, new Quaternion());
				}
			}
			
			Destroy(collision.gameObject);
			Events.FireBulletMissed();
		}
	}
}
