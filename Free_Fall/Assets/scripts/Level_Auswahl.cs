using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Auswahl : MonoBehaviour {
	private float leben;
	private float score;
	public GameObject level1_stern1;
	public GameObject level1_stern2;
	public GameObject level1_stern3;
	public GameObject level2_stern1;
	public GameObject level2_stern2;
	public GameObject level2_stern3;

	void Start () {
		leben =(float) PlayerPrefs.GetInt ("level1_leben", 0) ;
		score =  (float) PlayerPrefs.GetInt ("level1_score", 0) ;
		int  percLife = (int)( (leben/5f)* 100) ;
		int percScore = (int)((score/171f)*100) ;
		if(percLife == 100)
			level1_stern1.SetActive (true);
		if(percScore >= 75)
			level1_stern2.SetActive (true);
		if(percScore ==100)
			level1_stern3.SetActive (true);

		leben =(float) PlayerPrefs.GetInt ("level2_leben", 0) ;
		score =  (float) PlayerPrefs.GetInt ("level2_score", 0) ;
		percLife = (int)( (leben/5f)* 100) ;
		percScore = (int)((score/96f)*100) ;
		if(percLife == 100)
			level2_stern1.SetActive (true);
		if(percScore >= 75)
			level2_stern2.SetActive (true);
		if(percScore ==100)
			level2_stern3.SetActive (true);
	}
	// Use this for initialization
	public void level1_Wahl(){
		SceneManager.LoadScene ("level_1");
	}

	public void level2_Wahl(){
		SceneManager.LoadScene ("Level2");
	}

	public void menu_Wahl(){
		SceneManager.LoadScene ("main_menu");
	}
}
