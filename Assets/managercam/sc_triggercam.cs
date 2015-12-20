using UnityEngine;
using System.Collections;

public class sc_triggercam : MonoBehaviour
{

	public int camToID;
	public float speedMove;

	void Start ()
	{
		GetComponent<Renderer> ().enabled = false;
	}

}
