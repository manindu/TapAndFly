using UnityEngine;
using System.Collections;

//This script is used to check whether the bird has passed a gap in an obstacle. If so, we add a point and play a sound.
public class ScoreTriggerScript : MonoBehaviour {

	void OnTriggerExit2D (Collider2D coll) {
		
		if (coll.gameObject.CompareTag("Player")) {
			Debug.Log ("score");
			StateManager.current.AddScore ();
			AudioScript.current.PlayScoreSound();
		}
	}
}
