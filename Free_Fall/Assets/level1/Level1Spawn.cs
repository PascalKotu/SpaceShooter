using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level1Spawn : MonoBehaviour {
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

			if(Kreis_Stuerung.scoreValue > PlayerPrefs.GetInt ("level1_score", 0) )
				PlayerPrefs.SetInt ("level1_score", Kreis_Stuerung.scoreValue);

			if(player.getLeben () > PlayerPrefs.GetInt ("level1_leben", 0))
				PlayerPrefs.SetInt ("level1_leben", (int) player.getLeben ());

			PlayerPrefs.SetInt ("level1_score_last", Kreis_Stuerung.scoreValue);
			PlayerPrefs.SetInt ("level1_leben_last", (int) player.getLeben ());

			InvokeRepeating("nextLevel", 5, 2);
		}

	}

	void nextLevel(){
		Kreis_Stuerung.scoreValue = 0;
		SceneManager.LoadScene ("level_1_result");
	}

	void spawn(){
		spawns += 1;
		timePassed = 0;
		if (spawns == 10 || spawns == 20 || spawns == 30) { 
			float randX = Random.Range ((-cam_witdh/2) +( enemy.transform.lossyScale.x), (cam_witdh/2 )- (enemy.transform.lossyScale.x));
			Vector2 weretospawn = new Vector2 (randX, spawnpoint.transform.position.y);
			Instantiate (enemy, weretospawn, Quaternion.identity);
		}
		if (spawns == 1 || spawns == 2 || spawns == 4 || spawns == 5 || spawns == 7 || spawns == 8 ||
		    spawns == 11 || spawns == 12 || spawns == 14 || spawns == 15 || spawns == 17 || spawns == 18 ||
		    spawns == 21 || spawns == 22 || spawns == 24 || spawns == 25 || spawns == 27 || spawns == 28) {
			float randX = Random.Range ((-cam_witdh/2) +( 3*form1.transform.lossyScale.x), (cam_witdh/2 )- (3*form1.transform.lossyScale.x));
			Vector2 weretospawn = new Vector2 (randX, spawnpoint.transform.position.y);
			Instantiate (form1, weretospawn, Quaternion.identity);
		}
		if (spawns == 3 || spawns == 6 || spawns == 9 ||
		    spawns == 13 || spawns == 16 || spawns == 19 ||
		    spawns == 23 || spawns == 26 || spawns == 29) {
			float randX = Random.Range ((-cam_witdh/2) +( form2.transform.lossyScale.x), (cam_witdh/2 )- (form2.transform.lossyScale.x));
			Vector2 weretospawn = new Vector2 (randX, spawnpoint.transform.position.y);
			Instantiate (form2, weretospawn, Quaternion.identity);
		}

	}
}
