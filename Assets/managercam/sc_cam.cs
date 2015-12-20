using UnityEngine;
using System.Collections;

public class sc_cam : MonoBehaviour
{


	public int camID;

	void Start ()
	{
		GetComponent<Camera> ().enabled = false;
	}


	void Update ()
	{
	
	}
}
