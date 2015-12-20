using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject spawner;
	public GameObject mainAudio;
	public GameObject player;

	void Start() {
		spawner = GameObject.FindGameObjectWithTag ("Spawner");
		mainAudio = GameObject.FindGameObjectWithTag ("MainAudio");
		player = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<Renderer> ().enabled = false;
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.name == "Player")
		{
			spawner.GetComponent<Spawner> ().NextWave ();
			mainAudio.GetComponent<MainAudio> ().PlayEnemySong ();
			player.GetComponent<Player> ().setShootTrue ();
			Destroy (gameObject);
		}
	}
}
