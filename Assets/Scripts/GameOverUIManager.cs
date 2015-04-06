using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This script handles the UI in game over scene
public class GameOverUIManager : MonoBehaviour {

	public Text latestScore;
	private int score;

	void Start () {
		score = PlayerPrefs.GetInt ("LatestScore");
		latestScore.text = score.ToString ();
	}

	public void GoToGame () {
		Application.LoadLevel ("Game");
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Main");
		}
	}
}
