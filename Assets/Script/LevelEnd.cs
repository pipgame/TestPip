using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

		public string levelToLoad;
		public string levelToUnlock;

		public LevelManager theLevelManger;
		public Player thePlayer;
		public CameraMovement theCamera;

		public float wiatToMove;
		public float waitToLoad;

		public bool MoveToPlayer;
		string StoreCoinCount;

		void Start () {
			theLevelManger = FindObjectOfType<LevelManager> ();
			thePlayer = FindObjectOfType<Player> ();
			theCamera = FindObjectOfType<CameraMovement> ();
			MoveToPlayer = false;
		}

		void Update () {
			if (MoveToPlayer){
				thePlayer.myRigidbody.velocity = new Vector3 (thePlayer.MoveSpeed, thePlayer.myRigidbody.velocity.y, 0f);
			}
		}


		void OnTriggerEnter2D(Collider2D other) {
			if (other.tag == "Player") {
				StartCoroutine ("LevelToExitCo");
			}
		}

		public IEnumerator LevelToExitCo()
		{
			thePlayer.canMove = false;
			theCamera.targetFollow = false;
			theLevelManger.invincible = true;
			thePlayer.myRigidbody.velocity = Vector3.zero;
			theLevelManger.levelMusic.Stop ();
			theLevelManger.gameOverMusic.Play ();
			PlayerPrefs.SetInt ("CountCoins", theLevelManger.coinCount);
			PlayerPrefs.SetInt ("Live", theLevelManger.currentLives);

			PlayerPrefs.SetInt (levelToUnlock, 1);

			yield return new WaitForSeconds (wiatToMove);
			MoveToPlayer = true;

			yield return new WaitForSeconds (waitToLoad);
			SceneManager.LoadScene (levelToLoad);
	}
}