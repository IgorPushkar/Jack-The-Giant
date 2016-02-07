using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MusicController : MonoBehaviour {

	public static MusicController instance;

	private AudioSource audioSource;

	void Awake(){
		MakeSingleton ();
		audioSource = GetComponent<AudioSource> ();
	}

	void MakeSingleton(){
		if(instance != null){
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void PlayMusic(bool flag){
		if(flag){
			if(!audioSource.isPlaying){
				audioSource.Play ();
			}
		} else {
			if(audioSource.isPlaying){
				audioSource.Stop ();
			}
		}
	}
}
