using UnityEngine;
using System.Collections;

public class lookatcamera : MonoBehaviour {
	
	GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find( "MainCamera" );
		//camera.transform.Rotate( 0, 180, 0 );
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt( camera.transform.position );
		transform.Rotate( 0, 180, 0 );
	}
}
