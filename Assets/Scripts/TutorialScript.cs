using UnityEngine;
using System.Collections;

//handles the tutorial animation.
public class TutorialScript : MonoBehaviour {

	public GameObject player;
	public GameObject objectSpawner;



	void Update () {
		#if (UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER)
		if (Input.GetMouseButtonDown(0)) {
			player.GetComponent<Rigidbody2D>().isKinematic = false;
			objectSpawner.GetComponent<SpawnObstacles>().enabled = true;
			Destroy(gameObject);
		}
		#endif
		
		#if (UNITY_ANDROID || UNITY_IOS || UNITY_WP8)
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			
			if (touch.phase == TouchPhase.Began) {
				player.GetComponent<Rigidbody2D>().isKinematic = false;
				objectSpawner.GetComponent<SpawnObstacles>().enabled = true;
				Destroy(gameObject);
			}
		}
		#endif
	}
}
