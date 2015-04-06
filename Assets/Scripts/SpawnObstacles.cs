using UnityEngine;
using System.Collections;

//This script is used to spawn obstacles
public class SpawnObstacles : MonoBehaviour {

	public float interval = 1f;

	void OnEnable () {
		InvokeRepeating ("SpawnTowers", interval, interval);
	}
	
	void SpawnTowers() {
		GameObject obj = ObjectPool.current.GetObstacle ();
		obj.SetActive (true);
	}

	void OnDisable () {
		CancelInvoke ("SpawnTowers");
	}
}
