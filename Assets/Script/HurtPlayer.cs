using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	private LevelManager theLevelmanager;
	public int damageToGive;

	void Start () {
		theLevelmanager = FindObjectOfType<LevelManager> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			//theLevelmanager.Respwan ();
			theLevelmanager.HurtPlayer(damageToGive);
		}
	}
}