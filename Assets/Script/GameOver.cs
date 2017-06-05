using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string levelSlect;
	public string mainMenu;

	public LevelManager theLeveManger;

	void Start () {

		theLeveManger = FindObjectOfType<LevelManager> ();
	}
	

	void Update () {
		
	}

	public void Restart()
	{
		PlayerPrefs.SetInt ("CountCoins", 0);
		PlayerPrefs.SetInt ("Live", theLeveManger.startingLives);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		
	}

	public void LevelSelect()
	{
		PlayerPrefs.SetInt ("CountCoins", 0);
		PlayerPrefs.SetInt ("Live", theLeveManger.startingLives);
		SceneManager.LoadScene (levelSlect);
	}

	public void QuitToMainMenu()
	{
		SceneManager.LoadScene (mainMenu);
	}
}
