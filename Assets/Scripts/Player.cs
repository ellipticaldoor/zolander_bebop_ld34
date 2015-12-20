using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

	public float moveSpeed = 10;

	//Camera viewCamera;
	//PlayerController controller;
	GunController gunController;
	public bool shoot = false;

	GameObject player;
	private Animation anim;


	protected override void Start () {
		base.Start ();
		//controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
		//viewCamera = Camera.main;

		player = GameObject.Find ("astronautaAnim2");
		anim = player.GetComponent<Animation> ();
		Cursor.visible = false;
	}

	void FixedUpdate () {
		//Look input
//		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
//		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
//		float rayDistance;
//
//		if (groundPlane.Raycast (ray, out rayDistance)) {
//			Vector3 point = ray.GetPoint(rayDistance);
//			Debug.DrawLine(ray.origin, point, Color.red);
//
//			controller.LookAt(point);
//		}

		anim.GetComponent<Animation> ().CrossFade ("idle");

		if (Input.GetKey (KeyCode.Z) || Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow)) {
			transform.position += transform.forward * Time.fixedDeltaTime * moveSpeed;
			anim.GetComponent<Animation> ().CrossFade ("walk");

		}

		if (Input.GetKey (KeyCode.X) || Input.GetMouseButton(1) || Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(new Vector3(0, Time.fixedDeltaTime * 500, 0));
			anim.GetComponent<Animation> ().CrossFade ("walk");
		}

		if (shoot) {
			gunController.Shoot();
		}

		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}

	public void setShootTrue() {
		shoot = true;
	}

	public void setShootFalse() {
		shoot = false;
	}
}
