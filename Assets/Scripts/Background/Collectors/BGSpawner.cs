using UnityEngine;
using System.Collections;

public class BGSpawner : MonoBehaviour {

	private GameObject[] backgrounds;
	private float lastY;

	void Start(){
		GetBackgrounds ();
	}

	void GetBackgrounds(){
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");

		lastY = backgrounds [0].transform.position.y;

		for (int i = 1; i < backgrounds.Length; i++){
			if(backgrounds[i].transform.position.y < lastY){
				lastY = backgrounds [i].transform.position.y;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Background"){
			if(other.transform.position.y == lastY){
				Vector3 temp = other.transform.position;
				float height = ((BoxCollider2D)other).size.y;
				temp.y -= height;
				for(int i = 0; i < backgrounds.Length; i++){
					if(!backgrounds[i].gameObject.activeInHierarchy){
						lastY = backgrounds [0].transform.position.y;
						lastY = temp.y;
						backgrounds [i].transform.position = temp;
						backgrounds [i].SetActive (true);
						return;
					}
				}
			}
		}
	}
}
