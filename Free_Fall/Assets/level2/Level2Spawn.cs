using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level2Spawn : MonoBehaviour {
	public GameObject enemy;
	public GameObject form1;
	public GameObject form2;
	public GameObject spawnpoint;
	public float spawnRate = 5.0f;
	private float timePassed = 0f;
	private int spawns = 0;
	public Kreis_Stuerung player;
	public Image progressbar;

	public Text victory;

	public GameObject[] enemys;

	private Camera cam;
	private float cam_Height;
	private float cam_witdh;

	void Start(){
		cam = Camera.main;
		cam_Height = 2f *cam.orthographicSize;
		cam_witdh = cam_Height * cam.aspect;
		InvokeRepeating("spawn", 0, spawnRate);
	}
	void Update(){
		progressbar.fillAmount = (((float) spawns-1)+ (timePassed /spawnRate) )/ 30f ;
		timePassed += Time.deltaTime; 

		enemys = GameObject.FindGameObjectsWithTag ("enemy");
		if (spawns > 30 && player.isActiveAndEnabled && enemys.Length<1) {
			victory.gameObject.SetActive (true);

			if(Kreis_Stuerung.scoreValue > PlayerPrefs.GetInt ("level2_score", 0) )
				PlayerPrefs.SetInt ("level2_score", Kreis_Stuerung.scoreValue); 
			if(player.getLeben () > PlayerPrefs.GetInt ("level2_leben", 0))
				PlayerPrefs.SetInt ("level2_leben", (int) player.getLeben ());

			PlayerPrefs.SetInt ("level2_score_last", Kreis_Stuerung.scoreValue);
			PlayerPrefs.SetInt ("level2_leben_last", (int) player.getLeben ());

			InvokeRepeating("nextLevel", 5, 2);
		}

	}

	void nextLevel(){
		Kreis_Stuerung.scoreValue = 0;
		SceneManager.LoadScene ("level_2_result");
	}

	void spawn(){
		spawns += 1;
		if (spawns == 10 || spawns == 20 || spawns == 30) {
			float randX = Random.Range ((-cam_witdh / 2) + 0.5f, (cam_witdh / 2) - 0.5f);
			Vector2 weretospawn = new Vector2 (randX, spawnpoint.transform.position.y);
			Instantiate (enemy, weretospawn, Quaternion.identity);
		} else if( spawns <= 30) {
			float randX = Random.Range ((-cam_witdh/2) + 0.5f , (cam_witdh/2 ) - 0.5f);
			Vector2 weretospawn = new Vector2 (randX, spawnpoint.transform.position.y);
			Instantiate (form1, weretospawn, Quaternion.identity);
		}
		timePassed = 0f;

	}
}
