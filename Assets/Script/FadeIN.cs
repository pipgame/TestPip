using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIN : MonoBehaviour {

	public float fadeTime;
	public GameObject fadeScreen;
	public Image blackScreen;

	void Start () {
		fadeScreen.SetActive (true);
		blackScreen.CrossFadeAlpha (0f, fadeTime, false);
	}

	void Update () {
		StartCoroutine (FadScreenDestroy ());
		if (blackScreen.color.a == 0) 
		{
			fadeScreen.SetActive (false);

		}
	}

	IEnumerator FadScreenDestroy()
	{
		yield return new WaitForSeconds (1f);
		Destroy (blackScreen);
	}
}
