using UnityEngine;
using System.Collections;

public class sc_player_cam : MonoBehaviour
{
	public Transform mainCam;
	public Transform[] cams;
	public float moveSpeed;
	float animationStep;
	bool moving;
	int camToID;
	int actualCamID;
	Vector3 startMainCamPos;
	Quaternion startMainCamRot;
	float startMainCamFov;
	Camera mainCamCamera;
	float fovCamTo;

	void Start ()
	{
		mainCamCamera = mainCam.GetComponent<Camera> ();
		moving = true;
		camToID = 0;
		moveSpeed = 0.01f;
		animationStep = 0;
		fovCamTo = cams [camToID].GetComponent<Camera> ().fieldOfView;
		SaveStartData ();
		//camToID = 4;
	}


	void Update ()
	{
		if (moving) {
			SwapCam ();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "triggerCam") {
			camToID = other.GetComponent<sc_triggercam> ().camToID;

			if (camToID != actualCamID) {
				moveSpeed = other.GetComponent<sc_triggercam> ().speedMove;
				moving = true;
				animationStep = 0;
				SaveStartData ();
				fovCamTo = cams [camToID].GetComponent<Camera> ().fieldOfView;
			}
		}
	}


	void SwapCam ()
	{
		animationStep = animationStep + moveSpeed;
		if (animationStep > 1) {
			animationStep = 1;
			moving = false;
			actualCamID = camToID;
		}
		mainCam.position = Vector3.Lerp (startMainCamPos, cams [camToID].position, animationStep);
		mainCam.rotation = Quaternion.Lerp (startMainCamRot, cams [camToID].rotation, animationStep);
		mainCamCamera.fieldOfView = Mathf.Lerp (startMainCamFov, fovCamTo, animationStep);
	}

	void SaveStartData ()
	{
		startMainCamPos = mainCam.position;
		startMainCamRot = mainCam.rotation;
		startMainCamFov = mainCamCamera.fieldOfView;
	}
}
