using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string firstLevel;
	public string levelSelect;

	public string[] levelName;
	public int startingLives;

	void Start () {
		
	}

	void Update () {
		
	}

	public void NewGame () {

		SceneManager.LoadScene (firstLevel);
		for (int i = 0; i < levelName.Length; i++) {
			PlayerPrefs.SetInt (levelName [i], 0);
		}

		PlayerPrefs.SetInt ("CountCoins", 0);
		PlayerPrefs.SetInt ("Live", startingLives);

	}

	public void ContinueGame () {
		SceneManager.LoadScene (levelSelect);

	}

	public void QuitGame () {

		Application.Quit ();

	}
}
