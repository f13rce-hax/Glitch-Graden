using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Update is called once per frame
	void Update ()
	{
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (IsTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker); 
			} 
		}
	}

	void Spawn (GameObject myGameObject) {
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;  
	}

	bool IsTimeToSpawn (GameObject attackerGameObject)
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnsPerSeconds = 1 / meanSpawnDelay; 

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		float threshold = spawnsPerSeconds * Time.deltaTime / 5;

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
	}
}
