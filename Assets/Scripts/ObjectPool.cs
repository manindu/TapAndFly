using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This script creates a pool of obstacles and supplies them on request.
public class ObjectPool : MonoBehaviour {

	public static ObjectPool current;
	public GameObject obstacle;
	public int obstacleCount = 5;

	//A list that stores the obstacles
	private List<GameObject> obstacles;

	void Awake () {
		current = this;
	}

	//Inside the Start() we create a List and populate it with a number of obstacles.
	void Start () {
		obstacles = new List<GameObject>();
		for (int i=0; i<obstacleCount; i++) {
			GameObject obj = Instantiate(obstacle);
			obstacles.Add(obj);
		}
	}

	//This method returns an obstacle when invoked.
	public GameObject GetObstacle () {
		for (int i=0; i<obstacles.Count; i++) {
			if (!obstacles[i].activeInHierarchy) {
				return obstacles[i];
			}
		}
		GameObject obj = Instantiate (obstacle);
		obstacles.Add (obj);
		return obj;
	}
}
