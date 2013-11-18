using UnityEngine;
using System.Collections;

public class moverockup : MonoBehaviour {
	GameObject lightobject;
	// Use this for initialization
	void Start () {
		lightobject = GameObject.Find( "gatelight" );
	}
	
	// Update is called once per frame
	void Update () {
		if ( transform.position.y < 0 - 0.01f ) {
			transform.Translate( 0, 0.01f, 0 );
		} else {
			lightobject.light.enabled = false;
		}
	}
}
