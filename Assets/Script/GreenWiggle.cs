using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWiggle : MonoBehaviour {

	public Transform startPointG;
	public Transform endPointG;
	public float moveSpeedG;
	public Rigidbody2D myRigidBody;

	public bool moveDiection;

	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {

		if (moveDiection && transform.position.x > endPointG.position.x) 
		{
			moveDiection = false;
		}

		if (!moveDiection && transform.position.x < startPointG.position.x) 
		{
			moveDiection = true;
		}

		if (moveDiection) 
		{
			myRigidBody.velocity = new Vector3 (moveSpeedG, myRigidBody.velocity.y, 0f);
		} else{
			myRigidBody.velocity = new Vector3 (-moveSpeedG, myRigidBody.velocity.y, 0f);
		}
		
	}
}
