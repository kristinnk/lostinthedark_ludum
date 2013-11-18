using UnityEngine;
using System.Collections;

public class globalVariables : MonoBehaviour {
	
	public static int level;
	
	// Use this for initialization
	void Start () {
		level = 0;
		DontDestroyOnLoad(this);
	}
	
	void nextLevel() {
		level++;
	}
	
	void setLevel( int l ) {
		level = l;
	}
	
	int getLevel() {
		return level;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
