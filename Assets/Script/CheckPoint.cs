using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public Sprite flageClose;
	public Sprite openFalge;

	private SpriteRenderer theSpriteRender;

	void Start () {
		theSpriteRender = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			
			theSpriteRender.sprite = openFalge;
		}
	}
}