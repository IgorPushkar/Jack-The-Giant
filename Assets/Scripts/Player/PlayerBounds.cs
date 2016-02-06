using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour {

	private float minX, maxX;

	void Start(){
		SetMinAndMaxX ();
	}

	void Update(){
		Vector3 temp = transform.position;
		temp.x = Mathf.Clamp (temp.x, minX, maxX);
		transform.position = temp;
	}

	void SetMinAndMaxX(){
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		float width = GetComponent<SpriteRenderer>().bounds.size.x / 2;

		maxX = bounds.x - width;
		minX = -bounds.x + width;
	}
}
