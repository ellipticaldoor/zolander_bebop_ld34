using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerFinal : MonoBehaviour {

	public GameObject spawner;
	public GameObject mainAudio;
	public GameObject player;
	public GameObject goal;
	public GameObject goback;
	public GameObject fog;

	void Start() {
		spawner = GameObject.FindGameObjectWithTag ("Spawner");
		mainAudio = GameObject.FindGameObjectWithTag ("MainAudio");
		player = GameObject.FindGameObjectWithTag ("Player");
		goal = GameObject.FindGameObjectWithTag ("Goal");
		goback = GameObject.FindGameObjectWithTag ("goback");
		fog = GameObject.FindGameObjectWithTag ("fog");
		//GetComponent<Renderer> ().enabled = false;
		goback.SetActive (false);
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.name == "Player")
		{
			spawner.GetComponent<Spawner> ().NextWave ();
		
			mainAudio.GetComponent<MainAudio> ().PlayEnemySong ();
			player.GetComponent<Player> ().setShootTrue ();
			Destroy (gameObject);

			goal.GetComponent<Goal> ().setGoal ();
			GetComponent<Renderer> ().enabled = false;
			goback.SetActive (true);
			fog.SetActive (false);
		}
	}

	void FixedUpdate () {
		transform.Rotate(new Vector3(0, 0, -Time.fixedDeltaTime * 500));
	}
}
