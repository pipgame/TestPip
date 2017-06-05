 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour {

	public float moveSpeed;
	private bool canMove;
	public Rigidbody2D myRigidbody;

	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		canMove = false;
	}

	void OnBecameInvisible() {
		canMove = false;
	}

	void OnBecameVisible() {
		canMove = true;
	}

	void Update () {
		if (canMove) 
		{
			myRigidbody.velocity = new Vector3 (-moveSpeed, myRigidbody.velocity.x, 0f);
			canMove = false;
		}
	} 

	public void OnEnable()
	{
		canMove = false;
	}
}