using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthPickUp : MonoBehaviour {

	public int giveToHealth;
	public LevelManager theLevelManger;

	void Start () {
		theLevelManger = FindObjectOfType<LevelManager> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			theLevelManger.GiveHealth (giveToHealth);
			gameObject.SetActive (false);
		}
	}
}