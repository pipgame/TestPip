using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLives : MonoBehaviour {

	public int giveToLives;
	private LevelManager theLevelManger;

	void Start () {
		theLevelManger = FindObjectOfType<LevelManager> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			theLevelManger.AddToLives (giveToLives);
			gameObject.SetActive (false);
		}
	}
}
