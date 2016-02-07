using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;
	[SerializeField]
	private Text scoreText, coinText, lifeText, finalScoreText, finalCoinText;
	[SerializeField]
	private GameObject pausePanel, gameoverPanel;
	[SerializeField]
	private GameObject readyButton;

	void Awake(){
		MakeInstance ();
	}

	void Start(){
		Time.timeScale = 0f;
		readyButton.SetActive (true);
	}

	void MakeInstance(){
		if(instance == null){
			instance = this;
		}
	}

	public void PauseGame(){
		ClickSound ();
		Time.timeScale = 0;
		pausePanel.SetActive (true);
	}

	public void ResumeGame(){
		ClickSound ();
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}

	public void QuitGame(){
		ClickSound ();
		Time.timeScale = 1;
		GameObject.Find ("Player").SetActive (false);
		//SceneManager.LoadScene ("Main");
		FadeController.instance.StartFadeIn ("Main");
	}

	public void SetScoreCount(int scoreCount){
		scoreText.text = scoreCount.ToString ();
	}

	public void SetLifeCount(int lifeCount){
		lifeText.text = "x" + lifeCount.ToString ();
	}

	public void SetCoinCount(int coinCount){
		coinText.text = "x" + coinCount.ToString ();
	}

	public void ShowGameoverPanel(int finalScoreCount, int finalCoinCount){
		finalCoinText.text = finalCoinCount.ToString ();
		finalScoreText.text = finalScoreCount.ToString ();
		gameoverPanel.SetActive (true);
		StartCoroutine (LoadMainMenu ());
	}

	IEnumerator LoadMainMenu(){
		yield return new WaitForSeconds (3);
		//SceneManager.LoadScene ("Main");
		FadeController.instance.StartFadeIn ("Main");
	}

	public void StartGame(){
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}

	public void RestartLevel(){
		StartCoroutine (OnPlayerDeathRestart ());
	}

	IEnumerator OnPlayerDeathRestart(){
		yield return new WaitForSeconds (1);
		//SceneManager.LoadScene ("Gameplay");
		FadeController.instance.StartFadeIn ("Gameplay");
	}

	void ClickSound(){
		GameObject.Find ("Music Controller").GetComponent<ClickController>().PlayClickSound();
	}
}
