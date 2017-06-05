using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float MoveSpeed = 5.0f;
	public Rigidbody2D myRigidbody;
	public float jumpSpeed = 3.0f;

	public bool canMove;

	public Transform groundCheck;
	public float groundCheckRedius;
	public LayerMask whatIsGrounded;

	public bool isGrounded;
	public Animator myAnim;
	public Vector3 reSpwanPosition;
	public GameObject stompBox;
	public LevelManager theLeveManager;

	// Mobile UI
	public bool MoveHorizontal;
	public bool MoveVertical;

	public float knockbackForce;
	public float knockBackLengh;
	public float knockBackCounter;

	public float incvilityLength;
	public float incvilityCounter;  

	//audio
	public AudioSource jumpSound;
	public AudioSource heartSound;
	public AudioSource explosionSound;
 	
	public bool LevelSelect;

	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		reSpwanPosition = transform.position;
		theLeveManager = FindObjectOfType<LevelManager> ();
		canMove = true;
	}

	void Update () {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRedius, whatIsGrounded);
		if (knockBackCounter <= 0 && canMove) {
			if (MoveHorizontal || Input.GetAxisRaw ("Horizontal") > 0f) {
				myRigidbody.velocity = new Vector3 (MoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (MoveVertical || Input.GetAxisRaw ("Horizontal") < 0f) {
				myRigidbody.velocity = new Vector3 (-MoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			} else {
				myRigidbody.velocity = new Vector3 (0f, myRigidbody.velocity.y, 0f);
			}

			if (Input.GetButtonDown ("Jump") && isGrounded) {
				myRigidbody.velocity = new Vector3 (myRigidbody.velocity.y, jumpSpeed, 0f);
				jumpSound.Play ();
			}

		}

	    if (knockBackCounter > 0){
			   knockBackCounter -= Time.deltaTime;
				if (transform.localScale.x > 0) {
					 myRigidbody.velocity = new Vector3 (-knockbackForce, knockbackForce, 0f);
					} 
				else {
						myRigidbody.velocity = new Vector3 (knockbackForce, knockbackForce, 0f);
					}
			}
							
			if (incvilityCounter > 0) {
				incvilityCounter -= Time.deltaTime;
			}
			if (incvilityCounter <= 0) {
				theLeveManager.invincible = false;
			}
			myAnim.SetFloat ("Speed", Mathf.Abs (myRigidbody.velocity.x));
			myAnim.SetBool ("Grounded", isGrounded);

			if (myRigidbody.velocity.y < 0) {
				stompBox.SetActive (true);
			} else {
				stompBox.SetActive (false);
			} 

		if (!isGrounded) {
			LevelSelect = false;
		}
	}



	public void knockBackPlayer()
	{
		knockBackCounter = knockBackLengh;
		incvilityCounter = incvilityLength;
		theLeveManager.invincible = true;
	}

	public void PlayerForward()
	{
		MoveHorizontal = true;
	}

	public void PlayerBackward()
	{
		MoveVertical = true;
	}

	public void PlayerJump()
	{
		if (isGrounded) {
			myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, jumpSpeed, 0f);
			jumpSound.Play ();
			LevelSelect = true;
		}
	}

	public void PlayerMouseUp()
	{
		MoveVertical = false;
		MoveHorizontal = false;
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "KillPlane") {
			//transform.position = reSpwanPosition;
			theLeveManager.Respwan();
		}
		if (other.tag == "CheckPoint") {
			reSpwanPosition = other.transform.position;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
}