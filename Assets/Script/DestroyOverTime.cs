using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

	public float overTime =1.0f;

	void Start () {
		
	}
	

	void Update () {
		overTime = overTime - Time.deltaTime;
		if (overTime <= 0f) {
			Destroy (gameObject);
		}
	}
}