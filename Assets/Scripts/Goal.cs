using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Goal : MonoBehaviour {

	public GameObject player;
	public GameObject ship;
	private Animation anim;
	public bool ship_go;
	public GameObject goback;
	public GameObject goal;
	public GameObject HUD;


	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		ship = GameObject.FindGameObjectWithTag ("naveAnimada");
		goback = GameObject.FindGameObjectWithTag ("goback");
		HUD = GameObject.FindGameObjectWithTag ("HUD");
		anim = ship.GetComponent<Animation> ();
		GetComponent<Renderer> ().enabled = false;
		ship_go = false;
//		DynamicGI.UpdateEnvironment();
	}

	void OnTriggerEnter (Collider col)
	{
		{
			if (ship_go) {
				closeGoal ();
				anim.GetComponent<Animation> ().CrossFade ("nave_go");
				player.GetComponent<Renderer> ().enabled = false;
				player.GetComponent<Player> ().setShootFalse();

				goback.SetActive (false);
				HUD.SetActive (false);

				Transform[] playerChilds = player.GetComponentsInChildren<Transform>();

				foreach (Transform child in playerChilds) {
					child.GetComponent<Renderer> ().enabled = false;
				}
			}
		}
	}

	public void setGoal() {
		GetComponent<Renderer> ().enabled = true;
		ship_go = true;
	}

	public void closeGoal() {
		GetComponent<Renderer> ().enabled = false;
	}
}
