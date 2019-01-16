using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour {
	
	public static bool musicIsEnabeld;
	public static bool soundIsEnabeld;
	public Text score;
	public Text highscore;
	private int higestScore;
	// Use this for initialization
	void Start () {
		musicIsEnabeld = PlayerPrefs.GetInt ("music", 1) != 0;
		higestScore = PlayerPrefs.GetInt ("HighScore", 0);
		highscore.text = "HIGHSCORE: " +higestScore;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "SCORE: " + Kreis_Stuerung.scoreValue;
		if (higestScore < Kreis_Stuerung.scoreValue) {
			PlayerPrefs.SetInt ("HighScore", Kreis_Stuerung.scoreValue);
			highscore.text = "HighScore: " + Kreis_Stuerung.scoreValue;
		}

	}
}
