using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] enemys;
	public GameObject spawnpoint;
	public float spawnRate = 0.8f;
	private int spawns = 0;

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

	}
	void spawn(){
		spawns++;
		if (spawns % 10 == 0) {
			float randX = Random.Range ((-cam_witdh / 2) + (enemys [0].transform.lossyScale.x), (cam_witdh / 2) - (enemys [0].transform.lossyScale.x));
			Vector2 weretospawn = new Vector2 (randX, spawnpoint.transform.position.y);
			Instantiate (enemys [2], weretospawn, Quaternion.identity);
		} else {
			int randEnemy = Random.Range (0, 2);
			float randX = Random.Range ((-cam_witdh/2) +( enemys[0].transform.lossyScale.x), (cam_witdh/2 )- (enemys[0].transform.lossyScale.x));
			Vector2 weretospawn = new Vector2 (randX, spawnpoint.transform.position.y);
			Instantiate (enemys[randEnemy], weretospawn, Quaternion.identity);
		}

	}
}
