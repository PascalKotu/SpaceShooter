using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_Wahl : MonoBehaviour {

	public void arcade_Wahl(){
		SceneManager.LoadScene ("df");
	}
	public void story_Wahl(){
		SceneManager.LoadScene ("overworld");
	}
	public void options_Wahl(){
		SceneManager.LoadScene ("options");
	}
	public void reset_Wahl(){
		PlayerPrefs.DeleteAll ();
	}
}
