using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public int speedx;
	public int speedy;
	public int speedz;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(speedx,speedy,speedz)* Time.deltaTime);
	}
}
