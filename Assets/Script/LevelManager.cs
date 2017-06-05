using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float waitToRespwan = 1.0f;
	public Player thePlayer;
	public GameObject deathSplosion;
	public LevelEnd theLevelEnd;

	public int coinCount;
	public Text ScoreText;
	public AudioSource coinSound;


	public Image Heart1;
	public Image Heart2;
	public Image Heart3;

	public Sprite fullHeart;
	public Sprite halfHeart;
	public Sprite emplty;

	public int maxHealth;
	public int healthCount;

	public bool respwaning;

	public ResetOnRespwan[] objectOnReset;
	public bool invincible;

	public Text liveText;
	public int startingLives;
	public int currentLives;

	public GameObject gameOver;
	public AudioSource levelMusic;
	public AudioSource gameOverMusic;


	void Start () {
		
		thePlayer = FindObjectOfType<Player> ();
		theLevelEnd = FindObjectOfType<LevelEnd> ();
		ScoreText.text = "Score " + coinCount.ToString ();
		healthCount = maxHealth;
		objectOnReset = FindObjectsOfType<ResetOnRespwan> ();

		if (PlayerPrefs.HasKey ("CountCoins")) {
			coinCount = PlayerPrefs.GetInt ("CountCoins");
		}

		ScoreText.text = "Score :" + coinCount.ToString ();

		if(PlayerPrefs.HasKey("Live")){
			currentLives = PlayerPrefs.GetInt ("Live");
		} else {
			currentLives = startingLives;
		}

		gameOver.SetActive (false);
		levelMusic.Play ();
		gameOverMusic.Stop ();
		liveText.text = "Live x " + currentLives.ToString ();
	}

	void Update () {
		ScoreText.text = "Score :" + coinCount.ToString ();
		UpdateHeartMeter ();
		if (healthCount <= 0 && !respwaning)
		{
			Respwan ();
			respwaning = true;
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			if(Application.platform == RuntimePlatform.Android)
			{
				Application.Quit ();
			}
		}
	}

	public void Respwan()
	{
		currentLives -= 1;
		liveText.text = "Live x " + currentLives.ToString();

		if (currentLives > 0) {
			StartCoroutine (RespwanCo ());
		} else {
			thePlayer.gameObject.SetActive (false);
			gameOver.SetActive (true);
			levelMusic.Stop ();
			gameOverMusic.Play ();
		}

	}


	IEnumerator RespwanCo()
	{
		thePlayer.gameObject.SetActive (false);
		Instantiate (deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);
		yield return new WaitForSeconds (waitToRespwan);
		healthCount = maxHealth;
		respwaning = false;

		coinCount = 0;
		ScoreText.text = "Score :" + coinCount.ToString();

		thePlayer.transform.position = thePlayer.reSpwanPosition;
		thePlayer.gameObject.SetActive (true);

		for (int i = 0; i < objectOnReset.Length; i++) 
		{
			objectOnReset [i].ResetObject ();
			objectOnReset [i].gameObject.SetActive (true);
		}
	}

	public void GiveHealth(int giveToHealth)
	{
		healthCount += giveToHealth;
		coinSound.Play ();

		if (healthCount > maxHealth) {
			healthCount = maxHealth;
		}
		UpdateHeartMeter ();
	}


	public void AddCoin(int coinToAdd)
	{
		coinCount += coinToAdd;
		coinSound.Play ();
	}

	public void HurtPlayer(int damageToTake)
	{
		if (!invincible) {
			healthCount -= damageToTake;
			UpdateHeartMeter ();
			thePlayer.knockBackPlayer ();
			thePlayer.heartSound.Play ();
		}

	}


	public void UpdateHeartMeter()
	{
		switch (healthCount) 
		{
		case 6:
			Heart1.sprite = fullHeart;
			Heart2.sprite = fullHeart;
			Heart3.sprite= fullHeart;
				return;
		case 5:
			Heart1.sprite = fullHeart;
			Heart2.sprite = fullHeart;
			Heart3.sprite = halfHeart;
				return;
		case 4:
			Heart1.sprite = fullHeart;
			Heart2.sprite = fullHeart;
			Heart3.sprite = emplty;
			return;
		case 3:
			Heart1.sprite = fullHeart;
			Heart2.sprite = halfHeart;
			Heart3.sprite = emplty;
			return;
		case 2:
			Heart1.sprite = fullHeart;
			Heart2.sprite = emplty;
			Heart3.sprite = emplty;
			return;
		case 1:
			Heart1.sprite = halfHeart;
			Heart2.sprite = emplty;
			Heart3.sprite = emplty;
			return;
		case 0:
			Heart1.sprite = emplty;
			Heart2.sprite = emplty;
			Heart3.sprite = emplty;
			return;

		default :
			Heart1.sprite = emplty;
			Heart2.sprite = emplty;
			Heart3.sprite = emplty;
			return;
		}
	}


	public void  AddToLives(int takeTolives)
	{
		currentLives += takeTolives;
		liveText.text = "Live x " + currentLives.ToString ();
		coinSound.Play ();
	}
}