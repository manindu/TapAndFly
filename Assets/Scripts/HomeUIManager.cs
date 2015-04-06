using UnityEngine;
using System.Collections;

//This is the script that hold methods for homescreen buttons
public class HomeUIManager : MonoBehaviour {

	public void GoToGame () {
		Application.LoadLevel ("Game");
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
