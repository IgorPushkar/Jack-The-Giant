using UnityEngine;
using System.Collections;

public static class GamePreferences{

	const string EASY_KEY = "Easy";
	const string MEDIUM_KEY = "Medium";
	const string HARD_KEY = "Hard";

	const string EASY_SCORE_KEY = "EasyScore";
	const string MEDIUM_SCORE_KEY = "MediumScore";
	const string HARD_SCORE_KEY = "HardScore";

	const string EASY_COIN_SCORE_KEY = "EasyCoinScore";
	const string MEDIUM_COIN_SCORE_KEY = "MediumCoinScore";
	const string HARD_COIN_SCORE_KEY = "HardCoinScore";

	const string MUSIC_KEY = "Music";

	//NOTE Integers represents booleans
	// 0 - false, 1 - true;

	#region Difficulty
	public static void SetEasyDifficulty(){
		PlayerPrefs.SetInt (EASY_KEY, 1);
		PlayerPrefs.SetInt (MEDIUM_KEY, 0);
		PlayerPrefs.SetInt (HARD_KEY, 0);
	}

	public static void SetMediumDifficulty(){
		PlayerPrefs.SetInt (EASY_KEY, 0);
		PlayerPrefs.SetInt (MEDIUM_KEY, 1);
		PlayerPrefs.SetInt (HARD_KEY, 0);
	}

	public static void SetHardDifficulty(){
		PlayerPrefs.SetInt (EASY_KEY, 0);
		PlayerPrefs.SetInt (MEDIUM_KEY, 0);
		PlayerPrefs.SetInt (HARD_KEY, 1);
	}

	public static Difficulties GetDifficulty(){
		if(PlayerPrefs.HasKey(EASY_KEY) && PlayerPrefs.GetInt(EASY_KEY) == 1){
			return Difficulties.Easy;
		} else if(PlayerPrefs.HasKey(HARD_KEY) && PlayerPrefs.GetInt(HARD_KEY) == 1){
			return Difficulties.Hard;
		} else if(PlayerPrefs.HasKey(MEDIUM_KEY) && PlayerPrefs.GetInt(MEDIUM_KEY) == 1){
			return Difficulties.Medium;
		} else {
			SetMediumDifficulty ();
			return Difficulties.Medium;
		}
	}
	#endregion

	#region Score
	public static void SetScore(int score){
		if(score >= 0){
			switch (GetDifficulty ()) {
			case Difficulties.Easy:
				PlayerPrefs.SetInt (EASY_SCORE_KEY, score);
				break;
			case Difficulties.Hard:
				PlayerPrefs.SetInt (HARD_SCORE_KEY, score);
				break;
			case Difficulties.Medium:
			default:
				PlayerPrefs.SetInt (MEDIUM_SCORE_KEY, score);
				break;
			}
		} else {
			Debug.LogWarning ("Score cannot be negative");
		}
	}

	public static int GetScore(){
		switch(GetDifficulty ()){
		case Difficulties.Easy:
			if(!PlayerPrefs.HasKey(EASY_SCORE_KEY)){
				SetScore (0);
			}
			return PlayerPrefs.GetInt (EASY_SCORE_KEY);
		case Difficulties.Hard:
			if(!PlayerPrefs.HasKey(HARD_SCORE_KEY)){
				SetScore (0);
			}
			return PlayerPrefs.GetInt (HARD_SCORE_KEY);
		case Difficulties.Medium:
		default:
			if(!PlayerPrefs.HasKey(MEDIUM_SCORE_KEY)){
				SetScore (0);
			}
			return PlayerPrefs.GetInt (MEDIUM_SCORE_KEY);
		}
	}
	#endregion

	#region Coins
	public static void SetCoins(int score){
		if(score >= 0){
			switch (GetDifficulty ()) {
			case Difficulties.Easy:
				PlayerPrefs.SetInt (EASY_COIN_SCORE_KEY, score);
				break;
			case Difficulties.Hard:
				PlayerPrefs.SetInt (HARD_COIN_SCORE_KEY, score);
				break;
			case Difficulties.Medium:
			default:
				PlayerPrefs.SetInt (MEDIUM_COIN_SCORE_KEY, score);
				break;
			}
		} else {
			Debug.LogWarning ("Coins cannot be negative");
		}
	}

	public static int GetCoins(){
		switch(GetDifficulty ()){
		case Difficulties.Easy:
			if(!PlayerPrefs.HasKey(EASY_COIN_SCORE_KEY)){
				SetCoins (0);
			}
			return PlayerPrefs.GetInt (EASY_COIN_SCORE_KEY);
		case Difficulties.Hard:
			if(!PlayerPrefs.HasKey(HARD_COIN_SCORE_KEY)){
				SetCoins (0);
			}
			return PlayerPrefs.GetInt (HARD_COIN_SCORE_KEY);
		case Difficulties.Medium:
		default:
			if(!PlayerPrefs.HasKey(MEDIUM_COIN_SCORE_KEY)){
				SetCoins (0);
			}
			return PlayerPrefs.GetInt (MEDIUM_COIN_SCORE_KEY);
		}
	}
	#endregion

	#region Music
	public static void SetMusic(bool flag){
		int key = flag ? 1 : 0;
		PlayerPrefs.SetInt (MUSIC_KEY, key);
	}

	public static bool GetMusic(){
		if(!PlayerPrefs.HasKey(MUSIC_KEY)){
			SetMusic (true);
		}
		return PlayerPrefs.GetInt (MUSIC_KEY) == 1 ? true : false;
	}
	#endregion
}
