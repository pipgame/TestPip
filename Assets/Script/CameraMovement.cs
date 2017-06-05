using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject target;
	public float followHead;
	private Vector3 targetPositon;
	public float smoothing = 2.0f;
	public bool targetFollow; 

	void Start () {
		targetFollow = true;
	}

	void Update () {
		if (targetFollow) {
				targetPositon = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);

				if (target.transform.localScale.x > 0f) {
					targetPositon = new Vector3 (targetPositon.x + followHead, targetPositon.y, targetPositon.z);
				} else {
					targetPositon = new Vector3 (targetPositon.x - followHead, targetPositon.y, targetPositon.z);
				}

				transform.position = Vector3.Lerp (transform.position, targetPositon, smoothing * Time.deltaTime);
		}

	}
}		