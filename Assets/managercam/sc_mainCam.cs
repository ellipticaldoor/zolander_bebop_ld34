using UnityEngine;
using System.Collections;

public class sc_mainCam : MonoBehaviour
{

	public Transform player;
	public float camAdjustSpeed;
	public float leftTollerance;
	public float rightTollerance;

	public float screenW;
	public float screenH;

	public Vector3 testScreenposX;
	public float testTollerance;
	Vector3 screenPos;
	Camera cam;

	void Start ()
	{
		screenH = Screen.height;
		screenW = Screen.width;
		cam = GetComponent<Camera> ();
	}


	void FixedUpdate ()
	{
		
		screenPos = cam.WorldToScreenPoint (player.position);
		testScreenposX = screenPos;
		testTollerance =	Screen.width * leftTollerance;
		if (screenPos.x < Screen.width * leftTollerance) {
			//Debug.Log (" out cam");
			transform.Translate (Vector3.left * Time.fixedDeltaTime * 10);
		}

		if (screenPos.x > Screen.width * rightTollerance) {
			//Debug.Log (" out cam");
			transform.Translate (Vector3.right * Time.fixedDeltaTime * 10);
		}

	}
}
