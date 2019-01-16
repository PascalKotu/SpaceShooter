using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourShip3 : MonoBehaviour {
	public float speed = 2f;
	//public Transform pointOrigin;
	public GameObject explosion;

	public float maxleben = 1f;
	private float leben;
	public Image healthbar;

	private Camera cam;
	private float cam_Height;
	private float cam_witdh;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
		cam_Height = 2f *cam.orthographicSize;
		cam_witdh = cam_Height * cam.aspect;

		leben = maxleben;
	}
	void Update(){
		healthbar.fillAmount = leben / maxleben;
		if (leben < 1) {
			Kreis_Stuerung.scoreValue += (int)maxleben;
			Vector2 weretospawn = new Vector2 (this.transform.position.x, this.transform.position.y);
			Instantiate (explosion, weretospawn, Quaternion.identity);
			Destroy (this.gameObject);
		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y >= cam_Height/4) {
			Vector2 boxMovement = new Vector2 (0, -speed);
			transform.Translate (boxMovement * Time.deltaTime);
		}
	}

	public void setLeben(int damage){
		leben -= (float) damage;
	}

	private void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
