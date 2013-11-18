using UnityEngine;
using System.Collections;

public class scriptProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		//Destroy( collision.gameObject );
		Destroy( gameObject );
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = transform.forward * 5;
	}
}
