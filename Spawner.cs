using UnityEngine;
using System.Collections.Generic;

class Spawn {
	// Definition
	public int step = 1;
	public float time = 6f;
	public float elapsed = 0f;
	
	public Transform route;
	public Transform transform;
	public Spawn(Transform transform, Transform route) {
		this.transform = transform;
		this.route = route;
	}
	
	// A Catmull–Rom spline implementation
	public Vector3 MoveSmoothlyTo(int i, float t) {
		Vector3 point1, point2, point3, point4;
		float a = t*t*t;
		float v = t*t;
		
		if (i > 1) {
			point1 = GetPoint(i-2);
		} else {
			point1 = GetPoint(0);
		}
		
		if (i+1 < route.childCount) {
			point4 = GetPoint(i+1);
		} else {
			point4 = GetPoint(i);
		}
		
		point1 *= (-a/2f + v - t/2f);
		point2 = GetPoint(i-1) * (a*1.5f - v*2.5f + 1f);
		point3 = GetPoint(i) * (-a*1.5f + v*2f + t/2f);
		point4 *= (a/2f - v/2f);
		
		return point1 + point2 + point3 + point4;
	}
	
	public Vector3 GetPoint(int i) {
		return route.GetChild(i).position;
	}
}

public class Spawner : MonoBehaviour {
	public GameObject spawnPrefab;
	public GameObject[] routes; // routes are drawn in the editor using empty GameObjects
	
	List<Spawn> spawns = new List<Spawn>();
	float nextSpawn = 0;
	int numSpawns = 1;
	
	// Events
	void Start() {
		Events.MonsterKilled += MonsterKilled;
	}
	
	void MonsterKilled(Transform monster) {
		foreach(Spawn spawn in spawns) {
			if (spawn.transform == monster) {
				spawns.Remove(spawn);
				break;
			}
		}
	}
		
	// Calculate
	void Update () {
		if (Time.time > nextSpawn) {
			Transform route = routes[Random.Range(0, routes.Length)].transform;
			GameObject spawn = Instantiate(spawnPrefab, route.GetChild(0).position, new Quaternion()) as GameObject;
			
			spawns.Add(new Spawn(spawn.transform, route));
			nextSpawn = Time.time + 5f + Random.Range(4f, 6f) / Mathf.Pow(numSpawns, .2f);
			numSpawns += 1;
		}
		
		for (int i = 0; i < spawns.Count; i++) {
			Spawn spawn = spawns[i];
			spawn.elapsed += Time.smoothDeltaTime;
			
			Transform route = spawn.route;
			Transform transform = spawn.transform;
			Transform target = route.GetChild(spawn.step);
			
			if (spawn.elapsed > spawn.time) {
				spawn.step++;
				
				if (spawn.step < route.childCount) {
					spawn.elapsed -= spawn.time;
					spawn.time = Vector3.Distance(spawn.GetPoint(spawn.step - 1), spawn.GetPoint(spawn.step)) / 5;
					// not good enough for an aproximation. Need to work on it later.
				} else {
					spawns.RemoveAt(i);
					i--;
				}
			} else {
				transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, .3f);
				transform.position = spawn.MoveSmoothlyTo(spawn.step, spawn.elapsed / spawn.time);
			}
		}
	}
}
