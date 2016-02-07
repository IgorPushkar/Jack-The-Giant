using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour {

	[SerializeField]
	private AudioClip clickClip;
	private AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayClickSound(){
		audioSource.PlayOneShot (clickClip);
	}
}
