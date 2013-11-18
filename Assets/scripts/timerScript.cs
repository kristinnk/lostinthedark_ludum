using UnityEngine;
using System.Collections;

public class timerScript : MonoBehaviour {
	
	int counter;
	int lightCounter;
	int timeRemoved;
	int timeleftcounter;
	int textMode;
	int gameMode; // stores 0: darkmode, 1: lightmode
	Quaternion newAngle;
	Transform start;
	Transform target;
	GameObject light1;
	GameObject light2;
	float lightlevel1;
	float lightlevel2;
	float newlightlevel;
	GameObject camera;
	GameObject timertext;
	GameObject timeLeftText;
	Vector3 newPos;
	Vector3 posA;
	Vector3 posB;
	Quaternion angleA;
	Quaternion angleB;
	float angleXB;
	public GameObject player;
	
	void gameOver() {
		timertext.guiText.text = "Game over";
		Application.LoadLevel(3);
	}
	
	void lightMode() {
		gameMode = 1;
	}
	
	void darkMode() {
		gameMode = 0;
	}
	
	void Countdown() {
		
		timeLeftText.guiText.text = "You will be trapped in " + timeleftcounter.ToString() + " seconds.";
		timeleftcounter--;
		
		if ( timeRemoved == 10 ) {
			gameOver();
		} else {
			if ( textMode == 0 ) {
				darkMode();
				textMode = 1;
			}
			if ( textMode == 1 ) {
				if ( counter == 0 ) {
					textMode = 2;
				}
				timertext.guiText.text = "Light in : " + counter.ToString() + " seconds.";
				counter--;
			}
			if ( textMode == 2 ) {
				lightMode();
				textMode = 3;
			}
			if ( textMode == 3 ) {
				timertext.guiText.text = "Darkness in : " + lightCounter.ToString() + " seconds.";
				lightCounter--;
				if ( lightCounter == 0 ) {
					textMode = 4;
				}
			}
			if ( textMode == 4 )  {
				
				lightCounter = 10 - timeRemoved;
				timeRemoved = timeRemoved + 2;
				counter = 10;
				textMode = 0;				
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		counter 	 = 10;
		lightCounter = 10;
		timeRemoved = 2;
		timeleftcounter = 70;
		textMode = 1;
		timertext = GameObject.Find( "TimeUntilLight" );
		timeLeftText = GameObject.Find( "TimeLeft" );
		light1 = GameObject.Find("skylight1");
		light2 = GameObject.Find("skylight2");
		camera = GameObject.Find("MainCamera");
		
		posA = new Vector3( 0, 4.227299f, -3.71169f );
		posB = new Vector3( 0, 5f, -3.71169f );
		
		angleA = new Quaternion( Quaternion.Euler(45, 0, 0).x,Quaternion.Euler(45, 0, 0).y, Quaternion.Euler(45, 0, 0).z, Quaternion.Euler(45, 0, 0).w );
		angleB = new Quaternion( Quaternion.Euler(30, 0, 0).x,Quaternion.Euler(30, 0, 0).y, Quaternion.Euler(30, 0, 0).z, Quaternion.Euler(30, 0, 0).w );
		
		lightlevel1 = 0.0f;
		lightlevel2 = 0.15f;
		
		InvokeRepeating( "Countdown", 1.0f, 1.0f );
		gameMode = 0;
	}
	
		
	void changeMode() {
		switch ( gameMode ) {
			case 0: {
				newPos = posA;
				newAngle = angleA;
				newlightlevel = lightlevel1;
			} break;
			case 1: {
				newPos = posB;
				newAngle = angleB;
				newlightlevel = lightlevel2;
			} break;
			default: break;
		}
		
		light1.light.intensity = Mathf.Lerp( light1.light.intensity, newlightlevel, Time.deltaTime );
		camera.transform.localPosition = Vector3.Lerp( camera.transform.localPosition, newPos, Time.deltaTime );
		camera.transform.localRotation = Quaternion.Lerp( camera.transform.localRotation, newAngle, Time.deltaTime );
		
	}
	
	// Update is called once per frame
	void Update () {
		changeMode();
	}
}
