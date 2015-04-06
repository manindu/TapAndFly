using UnityEngine;
using System.Collections;

//This script controls the bird depending on the user input.
public class PlayerController : MonoBehaviour {

	public float yForce = 10f;
	private Rigidbody2D rb;
	private Animator anim;
	private Vector2 force;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		force = new Vector2 (0, yForce);
	}
	
	//Inside the update function we check whether the left mouse button is pressed or the display is touched. 
	//We have used pre-processor directives to check the platform and compile the code depending on the current platform.

	void Update () {
		#if (UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER)
		if (Input.GetMouseButtonDown(0)) {
			Flap ();
		}
		#endif

		#if (UNITY_ANDROID || UNITY_IOS || UNITY_WP8)
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
				Flap();
			}
		}
		#endif

	}

	//This method moves the bird up when the screen is tapped or clicked.
	void Flap () {
		rb.velocity = new Vector2(0, 0);
		rb.AddForce(force);
		AudioScript.current.PlayFlapSound();
	}

	//When the bird hits something we check what it is. We play different animations depending on the object that
	//the player has hit (obstalce, ground)
	//Then we call the GameOver() method.
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag("Obstacle")) {
			anim.SetInteger("AnimState", 1);
			rb.isKinematic = true;
			AudioScript.current.PlayHitSound();
			StateManager.current.GameOver();
		}
		if (col.gameObject.CompareTag("Ground")) {
			anim.SetInteger("AnimState", 2);
			rb.isKinematic = true;
			AudioScript.current.PlayHitSound();
			StateManager.current.GameOver();
		}
	}


}
