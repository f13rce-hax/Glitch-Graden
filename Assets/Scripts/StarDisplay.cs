using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private static Text starText;
	private static int stars = 100;

	// Use this for initialization
	void Start ()
	{
		starText = GetComponent<Text> ();
		Reset();
		UpdateDisplay();
	}

	public static void AddStars (int amount)
	{
		stars += amount;
		UpdateDisplay();
	}

	public Status UseStars (int amount)
	{
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;  
		} 
		return Status.FAILURE;
	}

	public static void UpdateDisplay ()
	{
		starText.text = stars.ToString();
	}

	void Reset ()
	{
		stars = 100;
	}
}

