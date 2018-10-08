using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds;

	private Slider gameTimer;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start ()
	{
		gameTimer = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin();
		winLabel.SetActive(false);
	}

	void FindYouWin (){
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Win label not found");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameTimer.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel) {
			HandleWinConditions ();
		}
	}

	void HandleWinConditions ()
	{
		DestroyAllTaggedObjects();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	// Destroys all game object with destroyOnWin tag
	void DestroyAllTaggedObjects ()
	{
		GameObject[] taggedObjectsArray = GameObject.FindGameObjectsWithTag ("destroyOnWin");

		foreach (GameObject taggedObject in taggedObjectsArray) {
			Destroy (taggedObject);
		}
	}

	void LoadNextLevel ()
	{
		levelManager.LoadNextLevel();
	}
}
