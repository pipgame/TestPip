using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject objectToMove;

	public Transform startPoint;
	public Transform endPoint;
	public float moveSpeedP;
	public Vector3 currentTarget;

	void Start () {
		currentTarget = endPoint.position;
	}

	void Update () {

		objectToMove.transform.position =  Vector3.MoveTowards (objectToMove.transform.position, currentTarget, moveSpeedP * Time.deltaTime);
		if (objectToMove.transform.position == endPoint.position) 
		{
			currentTarget = startPoint.position;
		}

		if (objectToMove.transform.position == startPoint.position) 
		{
			currentTarget = endPoint.position;
		}
		
	}
}
