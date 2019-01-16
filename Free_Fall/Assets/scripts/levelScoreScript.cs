using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelScoreScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		ScoreScript.musicIsEnabeld = PlayerPrefs.GetInt ("music", 1) != 0;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
