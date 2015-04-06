using UnityEngine;
using System.Collections;

//This script is used to move the obstacles to left.
public class MoveObstacle : MonoBehaviour {

	public float speed = 1f;
	public float minY = 0.3f;
	public float maxY = 2.3f;
			
	void OnEnable () {
		transform.position = new Vector3 (3f, Random.Range(minY, maxY), 0);
	}

	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * speed);

		if (transform.position.x <= -3f) {
			gameObject.SetActive(false);
		}
	}
}
