using UnityEngine;
using System.Collections;

public class enterTheGame : MonoBehaviour {
	
	GameObject score;
	// Use this for initialization
	void Start () {
		score = GameObject.Find( "score" );
		if ( score != null )
			score.guiText.text = "You escaped " + globalVariables.level + " times before falling.";
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			globalVariables.level = 0;
			Application.LoadLevel(1);
		}
	}
}
