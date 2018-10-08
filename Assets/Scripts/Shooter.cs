using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator anim;
	private Spawner myLaneSpawner;

	void Start ()
	{
		anim = GameObject.FindObjectOfType<Animator> ();

		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void SetMyLaneSpawner ()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in lane");
	}
	

	void Update ()
	{
		if (IsAttackerAheadInLane ()) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}
	}

	bool IsAttackerAheadInLane ()
	{
		//check if there are atteckers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		} 

		//check if attackers in lane are ahead 
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//attackers in lane but behind us
		return false;
	}

	public void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;  
	}
}
