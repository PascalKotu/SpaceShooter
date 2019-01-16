using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level1_ergebnisse : MonoBehaviour {
	private float leben;
	private float score;
	public Text life;
	public Text score1;
	private float leben2;
	private float score2;
	public GameObject level1_stern1;
	public GameObject level1_stern2;
	public GameObject level1_stern3;

	// Use this for initialization
	void Start () {
		leben =(float) PlayerPrefs.GetInt ("level1_leben_last", 0) ;
		score =  (float) PlayerPrefs.GetInt ("level1_score_last", 0) ;
		life.text = "LIFE: " + (int)( (leben/5f)* 100) +"%";
		score1.text = "KILLED: " + (int)((score/171f)*100) +"%";
		Debug.Log (score);
		leben2 =(float) PlayerPrefs.GetInt ("level1_leben", 0) ;
		score2 =  (float) PlayerPrefs.GetInt ("level1_score", 0) ;
		int  percLife = (int)( (leben2/5f)* 100) ;
		int percScore = (int)((score2/171f)*100) ;
		if (percLife == 100) {
			level1_stern1.SetActive (true);
		}
		if (percScore >= 75) {
			level1_stern2.SetActive (true);

		}
		if (percScore >= 100) {
			level1_stern3.SetActive (true);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void restart(){
		SceneManager.LoadScene ("level_1");
	}
	public void mainMenu(){
		SceneManager.LoadScene ("main_menu");
	}
}
