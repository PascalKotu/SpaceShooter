using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class optins_Functions : MonoBehaviour {
	public Image music;
	public Image sound;
	// Use this for initialization
	void Start () {
		music.gameObject.SetActive ((PlayerPrefs.GetInt("music", 1) == 0));
		sound.gameObject.SetActive ((PlayerPrefs.GetInt("sound", 1) == 0));
	}
	
	// Update is called once per frame
	void Update () {
		music.gameObject.SetActive ((PlayerPrefs.GetInt("music", 1) == 0));
		sound.gameObject.SetActive ((PlayerPrefs.GetInt("sound", 1) == 0));
	}

	public void back(){
		SceneManager.LoadScene ("main_menu");
	}

	public void setzeMusic(){
		PlayerPrefs.SetInt ("music", ((PlayerPrefs.GetInt ("music", 1) == 0)) ? 1 : 0);
	}
	public void setzeSound(){
		PlayerPrefs.SetInt ("sound", ((PlayerPrefs.GetInt ("sound", 1) == 0)) ? 1 : 0);
	}
}
