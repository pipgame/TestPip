using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour {

	public string levelToLoad;
	private Player thePlayer;
	private bool selectLavel;
	public bool unLocked;

	public Sprite doorBottonOpen;
	public Sprite doorTopOpen;
	public Sprite doorBottomClosed;
	public Sprite doorTopClosed;

	public SpriteRenderer doorTop;
	public SpriteRenderer doorBottom;

	void Start () {

		thePlayer = FindObjectOfType<Player> ();
		selectLavel = false;
		//PlayerPrefs.DeleteAll ();

		PlayerPrefs.SetInt ("Level1", 1);

		if (PlayerPrefs.GetInt(levelToLoad) == 1) {
			unLocked = true;
		} else {
			unLocked = false;
		}


		if (unLocked) {
			doorTop.sprite = doorTopOpen;
			doorBottom.sprite = doorBottonOpen;
		} else {
			doorTop.sprite = doorTopClosed;
			doorBottom.sprite = doorBottomClosed;
		}
	}

	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			selectLavel = true;
			if ((Input.GetKey(KeyCode.Space) || thePlayer.LevelSelect))
			{
				SceneManager.LoadScene (levelToLoad);
			}
		}
	}

	public void LoadLevel()
	{
		if (selectLavel) {
			SceneManager.LoadScene (levelToLoad);
			thePlayer.PlayerJump ();
		}
	}
}