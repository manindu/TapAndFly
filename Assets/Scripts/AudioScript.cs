using UnityEngine;
using System.Collections;

//This script handles the audio playback.
public class AudioScript : MonoBehaviour {

	public static AudioScript current;
	public AudioClip scoreSound;
	public AudioClip hitSound;

	private AudioSource source;

	void Awake () {
		current = this;
	}

	void Start () {
		source = GetComponent<AudioSource>();
	}

	//Plays a sound when scoring points.
	public void PlayScoreSound () {
		source.PlayOneShot (scoreSound);
	}
	//Plays a sound when the bird hits an obstacle or the ground.
	public void PlayHitSound () {
		source.PlayOneShot (hitSound);
	}
	//Plays a sound when player taps the screen.
	public void PlayFlapSound () {
		source.Play ();
	}
}
