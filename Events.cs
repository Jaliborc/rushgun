using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {
	// Delegate Types
	public delegate void voidDelegate();
	public delegate void intDelegate(int v);
	public delegate void transformDelegate(Transform v);
	
	// Events
	public static event voidDelegate GameOver;
	public static void FireGameOver() {
		GameOver();
	}
	
	public static event intDelegate BulletsChanged;
	public static void FireBulletsChanged(int v) {
		BulletsChanged(v);
	}
	
	public static event voidDelegate BulletMissed;
	public static void FireBulletMissed() {
		BulletMissed();
	}
	
	public static event transformDelegate MonsterKilled;
	public static void FireMonsterKilled(Transform monster) {
		MonsterKilled(monster);
	}
}
