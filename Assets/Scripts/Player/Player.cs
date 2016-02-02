using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
public class Player : MonoBehaviour {
	

	public float speed = 8.0f, maxVelocity = 4.0f;

	private Rigidbody2D rigidBody;
	private Animator animator;
	private RuntimePlatform platform;

	void Awake(){
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		platform = Application.platform;
	}

	void FixedUpdate(){
		PlayerMovement ();
	}

	void PlayerMovement(){
		float forceX = 0f;
		float velocity = Mathf.Abs (rigidBody.velocity.x);
		float horInput;

		if ((platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) && Input.touchCount > 0) {
			horInput = Mathf.Sign ((Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position)).x - transform.position.x);
		} else if (Input.GetMouseButton (0)){ 
			horInput = Mathf.Sign ((Camera.main.ScreenToWorldPoint (Input.mousePosition)).x - transform.position.x);
		} else {
			horInput = Input.GetAxisRaw ("Horizontal");
		}

		if(velocity < maxVelocity && horInput != 0){
			forceX = horInput > 0 ? speed : -speed;
			animator.SetBool ("Walk", true);
			Vector3 newScale = transform.localScale;
			newScale.x = Mathf.Abs (newScale.x) * horInput;
			transform.localScale = newScale;
		} else if(rigidBody.velocity.x == 0){
			animator.SetBool ("Walk", false);
		}

		rigidBody.AddForce (new Vector2 (forceX, 0));
	}
}