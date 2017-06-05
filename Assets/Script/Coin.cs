using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public LevelManager theLevelmanger;
	public int coinValue;

	void Start () {
		theLevelmanger = FindObjectOfType<LevelManager> ();
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			theLevelmanger.AddCoin (coinValue);
			//Destroy (gameObject);
			gameObject.SetActive (false);
		}
	}
}
