using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;
	[SerializeField]
	private GameObject[] collectables;
	private float distanceBetweenClouds = 3f;
	private float minX, maxX;
	private float lastCloudY;
	private float controlX;
	private GameObject player;

	void Awake(){
		controlX = 0f;
		SetMinAndMaxX ();
		CreateCloud();
		player = GameObject.Find ("Player");
	}

	void Start(){
		PositionPlayer ();
	}

	void SetMinAndMaxX(){
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		maxX = bounds.x - 0.5f;
		minX = -bounds.x + 0.5f;
	}

	void Shuffle(GameObject[] array){
		for(int i = 0; i < array.Length; i++){
			GameObject temp = array [i];
			int random = Random.Range (i, array.Length);
			array [i] = array [random];
			array [random] = temp;
		}
	}

	void CreateCloud(){
		Shuffle (clouds);

		float posY = 0f;

		for(int i = 0; i < clouds.Length; i++){
			Vector3 temp = clouds [i].transform.position;

			temp.y = posY;

			if(controlX == 0){
				temp.x = Random.Range (0f, maxX);
				controlX = 1;
			} else if (controlX == 1){
				temp.x = Random.Range (0f, minX);
				controlX = 2;
			} else if(controlX == 2){
				temp.x = Random.Range (1f, maxX);
				controlX = 3;
			} else if (controlX == 3){
				temp.x = Random.Range (-1, minX);
				controlX = 0;
			}

			lastCloudY = posY;
			clouds [i].transform.position = temp;

			posY -= distanceBetweenClouds;
		}
	}

	void PositionPlayer(){
		GameObject[] darkClouds = GameObject.FindGameObjectsWithTag ("Deadly");
		GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");
		Vector3 temp;

		for(int i = 0; i < darkClouds.Length; i++){
			if(darkClouds[i].transform.position.y == 0){
				temp = darkClouds [i].transform.position;
				darkClouds [i].transform.position = cloudsInGame [0].transform.position;
				cloudsInGame [0].transform.position = temp;
			}
		}

		temp = cloudsInGame [0].transform.position;

		for(int i = 0; i < cloudsInGame.Length; i++){
			if(temp.y < cloudsInGame[i].transform.position.y){
				temp = cloudsInGame [i].transform.position;
			}
		}

		temp.y += 0.8f;
		player.transform.position = temp;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Cloud" || other.tag == "Deadly"){
			if(other.transform.position.y == lastCloudY){
				Shuffle (clouds);
				Shuffle (collectables);

				Vector3 temp = other.transform.position;

				for(int i = 0 ; i < clouds.Length; i++){
					if(!clouds[i].activeInHierarchy){
						if(controlX == 0){
							temp.x = Random.Range (0f, maxX);
							controlX = 1;
						} else if (controlX == 1){
							temp.x = Random.Range (0f, minX);
							controlX = 2;
						} else if(controlX == 2){
							temp.x = Random.Range (1f, maxX);
							controlX = 3;
						} else if (controlX == 3){
							temp.x = Random.Range (-1, minX);
							controlX = 0;
						}

						temp.y -= distanceBetweenClouds;

						lastCloudY = temp.y;

						clouds[i].transform.position = temp;
						clouds[i].SetActive (true);
					}
				}
			}
		}
	}
}
