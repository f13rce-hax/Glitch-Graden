using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();

		anim.SetBool("isAttacked Bool", false);
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		Lizard lizard = collider.gameObject.GetComponent<Lizard> ();

		if (lizard) {
			anim.SetBool("isAttacked Bool", true);
		}
	}
}
