using UnityEngine;
using System.Collections;

//This script moves the ground objects to left and keeps them looping.
public class MoveGround : MonoBehaviour {

	public float speed = 5f;
	public GameObject other;

	private float otherWidth;
	private Vector3 distance;

	

	void Start () {
		otherWidth = other.GetComponent<SpriteRenderer> ().bounds.size.x;
		distance = new Vector3 (otherWidth, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * speed);

		
	}

	void OnBecameInvisible () {
		if (gameObject != null && other != null) {
			transform.position = other.transform.position + distance;
		}
	}

}
