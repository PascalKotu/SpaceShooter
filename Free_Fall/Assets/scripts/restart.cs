using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restart : MonoBehaviour {
	private bool gameIsPaused = false;
	public GameObject menu;
	public GameObject pause;
	public GameObject resume;
	// Use this for initialization
	void Start () {
		
	}
	public void reastrt(){
		Kreis_Stuerung.scoreValue = 0;
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name );
	}
	public void mainMenu(){
		Kreis_Stuerung.scoreValue = 0;
		Time.timeScale = 1f;
		SceneManager.LoadScene ("main_menu");
	}
	// Update is called once per frame
	void Update () {
	}

	public void pauseButton(){
		if (gameIsPaused) {
			gameIsPaused = false;
			Time.timeScale = 1f;
			menu.SetActive (false);
			pause.SetActive (true);
			resume.SetActive (false);
		} else {
			gameIsPaused = true;
			Time.timeScale = 0f;
			menu.SetActive (true);
			pause.SetActive (false);
			resume.SetActive (true);
		}
	}

}
