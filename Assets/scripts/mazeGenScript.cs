using UnityEngine;
using System.Collections;

public class mazeGenScript : MonoBehaviour {

	public GameObject wallObject;
	public GameObject floorObject;
	public GameObject player;
	public GameObject exit;
	public GameObject zombie;
	int zombieHorde;
	
	void Start () {
		int size_modifier = globalVariables.level;
		int size = size_modifier * 4 + 10 + 1;
		zombieHorde = size_modifier * 2;
		int mazeWidth = size;
		int mazeHeight = size;
		
		generateSideWinderMaze( mazeWidth, mazeHeight );
	}
	
	void spawnMaze( int mazeWidth, int mazeHeight, int[,] mNodes ) {
		transform.Rotate( -90, 0, 0 );
		
		//floor layer
		for ( int i = 0; i < mazeWidth; i++ ) {
			for ( int j = 0; j < mazeHeight; j++ ) {
				Vector3 pos;
				pos.x = i;
				pos.z = j;
				pos.y = 0;
				Instantiate( floorObject, pos, transform.rotation );
			}
		}
		
		//wall layer
		for ( int i = 0; i < mazeWidth; i++ ) {
			for ( int j = 0; j < mazeHeight; j++ ) {
				if ( mNodes[ i, j ] == 1 ) {
					Vector3 pos;
					pos.x = i;
					pos.z = j;
					pos.y = 1;
					//wallObject.transform.Rotate( 0, 0, 90 );
					
					Instantiate( wallObject, pos, transform.rotation );
				}
				if ( mNodes[ i, j ] == 2 ) {
					exit.transform.Translate( i, 0, j );
				}
			}
		}
		
		// Place zombies
		int numZombies = zombieHorde;
		
		while ( numZombies > 0 ) {
			int rx = Random.Range( 1, mazeWidth - 1 );
			int ry = Random.Range( 1, mazeHeight - 1 );
			if ( mNodes[ rx, ry ] == 0 ) {
				Vector3 pos;
				pos.x = rx;
				pos.z = ry;
				pos.y = 1;
				int rotateangle = 0;
				
				switch ( Random.Range( 0, 3 ) ) {
					case 0:	rotateangle = 90; break;
					case 1:	rotateangle = 180; break;
					case 2:	rotateangle = 270; break;
					default: break;
				}
				zombie.transform.rotation.eulerAngles.Set( 0, rotateangle, 0 );
				GameObject newzombie = (GameObject)Instantiate( zombie, pos, zombie.transform.rotation );
				newzombie.transform.Rotate( 0, rotateangle, 0 );
				numZombies--;
				Debug.Log("zombie placed");
			}
		}
		
		// place player
		player.transform.Translate( mazeWidth - 2, 1, 1 );
		player.transform.Rotate( 0, -45, 0 );
	}
	
	void generateSideWinderMaze( int mazeWidth, int mazeHeight ) {
		Debug.Log( "Generating SW maze." );
		int[,] mNodes = new int[ mazeWidth, mazeHeight ];
		// Null the mazenodes.
		for ( int i = 0; i < mazeWidth; i++ ) {
			for ( int j = 0; j < mazeHeight; j++ ) {
				mNodes[ i, j ] = 1;
			}
		}
		
		int wallCarveCount = 0;
		
		// i = x
		// j = z
		for ( int i = 1; i < mazeWidth - 1; i = i + 2 ) {
			for ( int j = 1; j < mazeHeight - 1; j = j + 2 ) {
				
				mNodes[ i, j ] = 0;
				if ( j == 1 && i < ( mazeWidth - 2 ) ) {
					mNodes[ i + 1, j ] = 0;
				} else {
					if ( ( Random.Range( 0, 3 ) != 0 ) && ( ( i + 1 ) != mazeWidth - 1 ) ) {
						mNodes[ i+1, j ] = 0;
						wallCarveCount++;
					} else {
						if ( j > 1 ) {
							mNodes[ i, j - 1 ] = 0;
						}
						wallCarveCount = 0;
					}
				}
			}
		}		
		
		// determine exit location
		
		if ( Random.Range( 0, 2 ) > 0 ) {
			int rx;
			rx = Random.Range( ( mazeWidth - 1) / 2, mazeWidth - 1);
			if ( rx % 2 != 0 )
				rx = mazeWidth - rx - 1; 
			else
				rx = mazeWidth - rx; 
			mNodes[ rx, mazeHeight - 1 ] = 2;
		} else {
			int ry;
			ry = Random.Range( ( mazeHeight - 1) / 2, mazeHeight - 1);
			if ( ry % 2 == 0 )
				ry = ry - 1;
			mNodes[ 0, ry ] = 2;
		}
		spawnMaze( mazeWidth, mazeHeight, mNodes );
	}
		
	void Update () {
		
	}
}
