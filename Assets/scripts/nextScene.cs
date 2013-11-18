using UnityEngine;
using System.Collections;

public class nextScene : MonoBehaviour {
	
	GameObject scoreText;
	GameObject timerText;
	int seconds_until_next_scene;
	
	void Countdown() {
		// currently not used
		seconds_until_next_scene--;
		timerText.guiText.text = seconds_until_next_scene + " seconds until you get trapped again!";
		if ( seconds_until_next_scene == 0 )
			Application.LoadLevel(1);
	}
	
	// Use this for initialization
	void Start () {
		globalVariables.level++;
		scoreText = GameObject.Find( "score" );
		scoreText.guiText.text = "You have survived " + globalVariables.level + " times.";
		seconds_until_next_scene = 10;
		//timerText = GameObject.Find( "timertext" );
		//InvokeRepeating( "Countdown", 1.0f, 1.0f );
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			Application.LoadLevel(1);
		}
	}
}
