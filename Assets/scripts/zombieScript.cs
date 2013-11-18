using UnityEngine;
using System.Collections;

public class zombieScript : MonoBehaviour {
	
	public int hitpoints;
	GameObject player;
	public 	GameObject zombieSpeak;
	Ray leftRay;
	Ray rightRay;
	Ray forwardRay;
	Ray backRay;
	int textDelay;
	bool playerFound;
	
	void Start () {
		playerFound = false;
		player = GameObject.Find( "ludumdude" );
		//zombieSpeak = GameObject.Find( "zombieSpeach" );
		textDelay 	= 5;
		leftRay 	= new Ray( transform.position, Vector3.left );
		rightRay 	= new Ray( transform.position, Vector3.right );
		forwardRay 	= new Ray( transform.position, Vector3.forward );
		backRay 	= new Ray( transform.position, Vector3.back );
		InvokeRepeating( "speak", 5.0f, 5.0f );
	}

	void OnCollisionEnter( Collision col ) {
		
		if ( col.gameObject.name == "preProjectile(Clone)" ) {
			hitpoints--;
		}
	}
	
	void speak() {
		//zombieSpeak.guiText.text = "dude";
		TextMesh ztext = zombieSpeak.GetComponent( typeof( TextMesh ) ) as TextMesh;
		
		switch ( Random.Range( 0, 40 ) ) {
		case 1: ztext.text = "Help..."; break;
		case 2: ztext.text = "Help me"; break;
		case 3: ztext.text = "I'm cold"; break;
		case 4: ztext.text = "Its so dark"; break;
		case 5: ztext.text = "I'm scared"; break;
		case 6: ztext.text = "The maze closed on me..."; break;
		case 7: ztext.text = "Why cant I breathe?"; break;
		case 8: ztext.text = "Where am I?"; break;
		case 9: ztext.text = "Am I a monster now?"; break;
		case 10: ztext.text = "I was so close..."; break;
		case 11: ztext.text = "I miss my family"; break;
		case 12: ztext.text = "Who's thheeerreeehhhh..."; break;
		case 13: ztext.text = "Save me!"; break;
		case 14: ztext.text = "How did this happen?"; break;
		case 15: ztext.text = "Why me?"; break;
		default: ztext.text = ""; break;
		}
	}
	
	void gameOver() { 
	 // TODO: Implement this
	}
	
	void Update () {
		
		if ( hitpoints == 0 ) {
			gameOver();
		}
		
		int viewDistance = 3;
		RaycastHit hit;
		
		// check if we see the player
		/*
		 * if ( Physics.Raycast( leftRay, out hit, viewDistance ) |
			 Physics.Raycast( rightRay, out hit, viewDistance ) |
			 Physics.Raycast( forwardRay, out hit, viewDistance ) |
			 Physics.Raycast( backRay, out hit, viewDistance )
			 )  */
		if ( Physics.Raycast( leftRay, out hit, viewDistance ) ) {
		if ( hit.collider.name == player.name ) {
			playerFound = true;
		} else {
		}}
			
		if ( Physics.Raycast( rightRay, out hit, viewDistance ) ) {
		if ( hit.collider.name == player.name ) {
			playerFound = true;
		} else {
		}}
				
		if ( Physics.Raycast( backRay, out hit, viewDistance ) ) {
		if ( hit.collider.name == player.name ) {
			playerFound = true;
		} else {		
		}}
					
		if ( Physics.Raycast( forwardRay, out hit, viewDistance + 2 ) ) {
		if ( hit.collider.name == player.name ) {
			playerFound = true;
		} else {
		}}
		
		if ( playerFound == true ) {
			animation.CrossFade( "walk" );
			transform.LookAt( player.transform.position );
			rigidbody.velocity = transform.forward * 1;
		}
		
		if ( playerFound == false ) {
			animation.CrossFade( "stand_idle" );
		}
		
		if ( hitpoints == 0 ) {
			Destroy(gameObject);
		}
		
	}
}
