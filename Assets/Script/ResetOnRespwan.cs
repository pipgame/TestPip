using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnRespwan : MonoBehaviour {

	private Vector3 startPositon;
	private Vector3 startLocalScale;
	private Quaternion startRotation;

	private Rigidbody2D myRigidbody;

	void Start () {
		startPositon = transform.position;
		startRotation = transform.rotation;
		startLocalScale = transform.localScale;

		if(GetComponent<Rigidbody2D>() != null)
		{
			myRigidbody = GetComponent<Rigidbody2D> ();
		}
	}

	void Update () {
		
	}

	public void ResetObject()
	{
		transform.position = startPositon;
		transform.rotation = startRotation;
		transform.localScale = startLocalScale;
		if (myRigidbody != null) 
		{
			myRigidbody.velocity = Vector3.zero;
		}
	}
}