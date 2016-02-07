using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip, lifeClip;
	private AudioSource audioSource;
	private CameraScript cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int scoreCount;
	public static int lifeCount;
	public static int coinCount;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		cameraScript = Camera.main.GetComponent<CameraScript> ();
	}

	void Start(){
		previousPosition = transform.position;
		countScore = true;
	}

	void Update(){
		CountScore ();
	}

	void CountScore(){
		if(countScore){
			if(transform.position.y < previousPosition.y){
				scoreCount++;
				GameplayController.instance.SetScoreCount (scoreCount);
			}
			previousPosition = transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Coin"){
			coinCount++;
			scoreCount += 200;
			GameplayController.instance.SetCoinCount (coinCount);
			GameplayController.instance.SetScoreCount (scoreCount);
			AudioSource.PlayClipAtPoint (coinClip, other.transform.position);
			other.gameObject.SetActive (false);
		}
		if (other.tag == "Life"){
			lifeCount++;
			scoreCount += 300;
			GameplayController.instance.SetLifeCount (lifeCount);
			GameplayController.instance.SetScoreCount (scoreCount);
			AudioSource.PlayClipAtPoint (lifeClip, other.transform.position);
			other.gameObject.SetActive (false);
		}
		if (other.tag == "Bounds" || other.tag == "Deadly") {
			transform.position = new Vector3 (500, 500, 0);
			cameraScript.moveCamera = false;
			countScore = false;
			lifeCount--;
			GameManager.instance.CheckGameStatus (scoreCount, coinCount, lifeCount);
		}
	}
}
