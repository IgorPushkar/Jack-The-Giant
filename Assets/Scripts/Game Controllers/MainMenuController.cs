using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	private Animator animator;
	[SerializeField]
	private Text scoreText, coinText;
	[SerializeField]
	private GameObject easyCheckMark, mediumCheckMark, hardCheckMark;
	[SerializeField]
	private Button musicButton;
	[SerializeField]
	private Sprite[] musicIcons;

	void Awake(){
		animator = GameObject.Find ("Menu Canvas").GetComponent<Animator> ();
	}

	void Start(){
		SetScore ();
		SetCheckMarks ();
		SetMusic ();
	}

	void SetMusic(){
		bool musicState = GamePreferences.GetMusic ();
		int index = musicState ? 1 : 0;
		musicButton.image.sprite = musicIcons [index];
		MusicController.instance.PlayMusic (musicState);
	}

	void SetScore(){
		scoreText.text = GamePreferences.GetScore().ToString();
		coinText.text = GamePreferences.GetCoins().ToString ();
	}

	public void OnClick(string trigger){
		animator.SetTrigger (trigger);
	}

	public void OnStart(string level){
		GameManager.instance.startedFromMain = true;
		animator.SetTrigger ("Start");
		StartCoroutine ("WaitAndLoad", level);
	}

	IEnumerator WaitAndLoad(string level){
		yield return new WaitUntil (() => animator.IsInTransition(0));
		yield return new WaitUntil (() => !animator.IsInTransition(0));
		SceneManager.LoadScene (level);
	}

	public void ToggleMusic (){
		GamePreferences.SetMusic (!GamePreferences.GetMusic ());
		SetMusic ();
	}

	public void ChangeDifficulty(string newDifficulty){
		switch(newDifficulty){
		case "Easy":
			GamePreferences.SetEasyDifficulty ();
			break;
		case "Medium":
			GamePreferences.SetMediumDifficulty ();
			break;
		case "Hard":
			GamePreferences.SetHardDifficulty ();
			break;
		}
		SetScore ();
		SetCheckMarks ();
	}

	void SetCheckMarks(){
		switch (GamePreferences.GetDifficulty()){
		case Difficulties.Easy:
			easyCheckMark.SetActive (true);
			mediumCheckMark.SetActive (false);
			hardCheckMark.SetActive (false);
			break;
		case Difficulties.Medium:
			easyCheckMark.SetActive (false);
			mediumCheckMark.SetActive (true);
			hardCheckMark.SetActive (false);
			break;
		case Difficulties.Hard:
			easyCheckMark.SetActive (false);
			mediumCheckMark.SetActive (false);
			hardCheckMark.SetActive (true);
			break;
		}
	}
		
	public void OnQuitClick(){
		Application.Quit ();
	}
}
