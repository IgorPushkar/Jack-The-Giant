using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private float speed = 1f;
	private float acceleration = 0.2f;
	private float maxSpeed = 4.0f;

	private float easySpeed = 3.5f;
	private float mediumSpeed = 4.0f;
	private float hardSpeed = 4.5f;

	[HideInInspector]
	public bool moveCamera;

	void Start(){
		switch(GamePreferences.GetDifficulty()){
		case Difficulties.Easy:
			maxSpeed = easySpeed;
			break;
		case Difficulties.Medium:
			maxSpeed = mediumSpeed;
			break;
		case Difficulties.Hard:
			maxSpeed = hardSpeed;
			break;
		}

		moveCamera = true;
	}

	void Update(){
		if (moveCamera) {
			MoveCamera ();
		}
	}

	void MoveCamera(){
		Vector3 temp = transform.position;

		float oldY = temp.y;
		float newY = temp.y - (speed * Time.deltaTime);

		temp.y = Mathf.Clamp (temp.y, oldY, newY);

		transform.position = temp;

		if (speed < maxSpeed) {
			speed += acceleration * Time.deltaTime;
		}
	}
}
