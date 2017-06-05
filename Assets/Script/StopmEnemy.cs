using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopmEnemy : MonoBehaviour {

	private Rigidbody2D myRigidbody;
	public float bounceForce;
	public GameObject deadSposion;
	private Player theplayer;

	void Start () {
		theplayer = FindObjectOfType<Player> ();
		myRigidbody = transform.parent.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			//Destroy (other.gameObject);
			other.gameObject.SetActive(false);
			Instantiate(deadSposion, other.transform.position, other.transform.rotation);
			myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, bounceForce, 0f);
			theplayer.explosionSound.Play ();
		}
	}
}