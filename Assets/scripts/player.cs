using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public GameObject projectile;
	public int hitpoints;
	GameObject guitext;
	GameObject bullets;
	GameObject playerSpeak;
	TextMesh ptext;
	int numbullets;
	
	// Use this for initialization
	void Start () {
		guitext = GameObject.Find( "Hitpointslefttext2" );
		bullets = GameObject.Find( "bulletstext" );
		numbullets = 9;
		playerSpeak = GameObject.Find( "playerText" );
		ptext = playerSpeak.GetComponent( typeof( TextMesh ) ) as TextMesh;
		
		switch ( globalVariables.level ) {
		case 0: ptext.text = "Where am I? Wait! Is that light up ahead?"; break;
		case 1: ptext.text = "Well, that was not an exit. This must lead out eventually!"; break;
		case 2: ptext.text = "Shit! Were those zombies? How did they get here?"; break;
		case 3: ptext.text = "Were they speaking to me?"; break;
		case 4: ptext.text = "I must get out before I become one of them!"; break;
		case 5: ptext.text = "Must get out!"; break;
		case 6: ptext.text = "So cold..."; break;
		default: ptext.text = ""; break;
		}
		
		Invoke( "clearText", 5f );
	}
	
	void clearText() {
		ptext.text = "";
	}
	
	void gameOver() {
		Application.LoadLevel(3);
	}
	
	void OnCollisionEnter( Collision col ) {
		if ( col.gameObject.name == "preZombie(Clone)" |
			 col.gameObject.name == "preZombie" ) {
			Debug.Log( "Zombie hit with : " + col.gameObject.name );
			hitpoints--;
		}
		if ( col.gameObject.name == "exitCube" ) {
			Application.LoadLevel(2);
		}
	}

	// Update is called once per frame
	void Update () {
		if ( hitpoints == 0 ) {
			gameOver();
		}
		
		// forwards
		if ( Input.GetKey( KeyCode.W ) ) {
				animation.CrossFade( "walk" );
				rigidbody.velocity = transform.forward * 4;
		}
		if ( Input.GetKeyUp( KeyCode.W ) ) {
			animation.CrossFade( "stand_idle" );
			rigidbody.velocity = transform.forward * 0;
		}
		
		// backwards
		if ( Input.GetKey( KeyCode.S ) ) {
				animation.CrossFade( "walk" );
				rigidbody.velocity = transform.forward * -2;
		}
		if ( Input.GetKeyUp( KeyCode.S ) ) {
			animation.CrossFade( "stand_idle" );
			rigidbody.velocity = transform.forward * 0;
		}
		
		// strafe left
		if ( Input.GetKey( KeyCode.Q ) ) {
				animation.CrossFade( "walk" );
				rigidbody.velocity = transform.right * -4;
		}
		if ( Input.GetKeyUp( KeyCode.Q ) ) {
			animation.CrossFade( "stand_idle" );
			rigidbody.velocity = transform.right * 0;
		}
		
		// strafe right
		if ( Input.GetKey( KeyCode.E ) ) {
				animation.CrossFade( "walk" );
				rigidbody.velocity = transform.right * 4;
		}
		if ( Input.GetKeyUp( KeyCode.E ) ) {
			animation.CrossFade( "stand_idle" );
			rigidbody.velocity = transform.right * 0;
		}
		
		// rotate
		if ( Input.GetKey( KeyCode.A ) ) {
				rigidbody.transform.Rotate( 0, -3, 0 );
		}
		
		if ( Input.GetKey( KeyCode.D ) ) {
				rigidbody.transform.Rotate( 0, 3, 0 );
		}
		
		if (Input.GetKeyDown( KeyCode.Space ) ) {
			if ( numbullets > 0 ) {
				animation.CrossFade( "attack" );
				Instantiate( projectile, ( transform.position + ( transform.forward / 2 ) ), transform.rotation );
				numbullets--;
				bullets.guiText.text = numbullets + " bullets";
			}
		}
		
		guitext.guiText.text = hitpoints.ToString();
		
	}
}
