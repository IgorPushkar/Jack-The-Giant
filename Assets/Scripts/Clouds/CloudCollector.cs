using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Cloud" || other.tag == "Deadly"){
			Destroy (other.gameObject);
		}
	}
}
