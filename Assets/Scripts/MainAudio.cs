using UnityEngine;
using System.Collections;

public class MainAudio : MonoBehaviour {
	public AudioClip isolated;
	public AudioClip faster_does_it;

	float isolated_time = 0;
	float faster_does_it_time= 0;

	AudioSource audio;

	IEnumerator Start() {
		audio = GetComponent<AudioSource>();
		audio.Play();
		yield return new WaitForSeconds(0);
		audio.clip = isolated;
		audio.Play();
	}

	public void PlayEnemySong() {
		if (audio.clip.name != "faster_does_it") {
			isolated_time = audio.time; 
			audio.clip = faster_does_it;

			audio.Play();
			audio.time = faster_does_it_time;
		}
	}

	public void PlayThemeSong() {
		if (audio.clip.name != "isolated") {
			faster_does_it_time = audio.time;
			audio.clip = isolated;

			audio.Play();
			audio.time = isolated_time;
		}
	}
}
