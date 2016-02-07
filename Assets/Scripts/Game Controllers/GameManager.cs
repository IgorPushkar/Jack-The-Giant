using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool startedFromMain, restartedAfterDeath;

	[HideInInspector]
	public int scoreCount, coinCount, lifeCount;

	void Awake(){
		MakeSingleton ();
	}

	void MakeSingleton(){
		if(instance != null){
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void OnLevelWasLoaded(){
		if(SceneManager.GetActiveScene().name == "Gameplay"){
			if (startedFromMain){
				scoreCount = 0;
				coinCount = 0;
				lifeCount = 2;
			}
			GameplayController.instance.SetScoreCount (scoreCount);
			GameplayController.instance.SetCoinCount (coinCount);
			GameplayController.instance.SetLifeCount (lifeCount);

			PlayerScore.scoreCount = scoreCount;
			PlayerScore.coinCount = coinCount;
			PlayerScore.lifeCount = lifeCount;
		}
	}

	public void CheckGameStatus(int scoreCount, int coinCount, int lifeCount){
		if(lifeCount < 0){
			startedFromMain = false;
			restartedAfterDeath = false;

			GameplayController.instance.ShowGameoverPanel (scoreCount, coinCount);
		} else {
			this.scoreCount = scoreCount;
			this.coinCount = coinCount;
			this.lifeCount = lifeCount;

			restartedAfterDeath = true;
			startedFromMain = false;

			GameplayController.instance.RestartLevel ();
		}
	}
}
