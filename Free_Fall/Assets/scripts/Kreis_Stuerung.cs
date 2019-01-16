using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kreis_Stuerung : MonoBehaviour {
	public static int scoreValue = 0;
	public float speed = 2f;
	public GameObject schuss;
	private float zeitVergange = 0f; 
	public GameObject explosion;
	public GameObject menu;
	public GameObject pause;
	public float maxleben = 5f;
	private float leben;
	public Image healthbar;

	private Camera cam;
	private float cam_Height;
	private float cam_witdh;

	public float shootRate= 0.8f;
	private Vector2 touch;

	void Start () {
		leben = maxleben;
		menu.SetActive (false);
		pause.SetActive (true);

		cam = Camera.main;
		cam_Height = 2f *cam.orthographicSize;
		cam_witdh = cam_Height * cam.aspect;

		transform.position = new Vector3 (0, -cam_Height/4, 0);


		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = true;
		Screen.orientation = ScreenOrientation.Portrait;
	}

	void Update(){
		healthbar.fillAmount = leben / maxleben;
		if (leben < 1) {
			Vector2 weretospawn = new Vector2 (this.transform.position.x, this.transform.position.y);
			Instantiate (explosion, weretospawn, Quaternion.identity);
			menu.SetActive (true);
			pause.SetActive (false);
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		zeitVergange += Time.deltaTime; 
		if (zeitVergange > shootRate) {
			zeitVergange = 0f;
			shoot ();
		}
		if (Input.touches.Length > 0) {
			touch = Input.GetTouch (0).position;
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				Vector3 objpos = Camera.main.ScreenToWorldPoint (touch);
				objpos.z = 0;
				transform.position = Vector3.MoveTowards(transform.position ,objpos, speed*Time.deltaTime);

			}
		}
	}
	public void shoot(){
		Vector2  weretospawn = new Vector2 (this.transform.position.x  , this.transform.position.y + this.transform.lossyScale.y/4);
		Instantiate (schuss, weretospawn, Quaternion.identity);
	}


	public void setLeben(int damage){
		leben -= (float) damage;
	}

	public float getLeben(){
		return leben;
	}
}
