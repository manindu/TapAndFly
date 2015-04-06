using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This script is used for keep track of the score and handle game states.
public class StateManager : MonoBehaviour {

	public static StateManager current;
	public Text scoreText;

	private GameObject objectSpawner;
	private GameObject[] grounds;
	private GameObject[] obstacles;

	private int score;
	
	void Awake () {
		current = this;
	}

	void Start () {
		score = 0;
		objectSpawner = GameObject.FindGameObjectWithTag ("Spawner");
	}
	//Here we stop the moving objects and the spawner.Then we call the GotoGameOver() method.
	public void GameOver () {
		objectSpawner.SetActive (false);
		grounds = GameObject.FindGameObjectsWithTag ("Ground");
		for (int i=0; i<grounds.Length; i++) {
			grounds[i].GetComponent<MoveGround>().enabled = false;
		}

		obstacles = GameObject.FindGameObjectsWithTag ("ObstacleHolder");
		for (int i=0; i<obstacles.Length; i++) {
			obstacles[i].GetComponent<MoveObstacle>().enabled = false;
		}
		PlayerPrefs.SetInt ("LatestScore", score);
		Invoke ("GotoGameOver", 2f);

	}

	//Adds 1 to the current score and set the score text on the screen.
	public void AddScore () {
		score += 1;
		scoreText.text = score.ToString ();
	}

	void GotoGameOver () {
		Application.LoadLevel ("GameOver");
	}


}
