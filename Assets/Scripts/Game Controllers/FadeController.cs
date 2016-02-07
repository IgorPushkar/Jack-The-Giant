using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeController : MonoBehaviour {

	public static FadeController instance;
	[SerializeField]
	private GameObject fadePanel;
	[SerializeField]
	private Animator anim;

	void Start(){
		instance = this;
		StartFadeOut ();
	}

	public void StartFadeIn(string level){
		StartCoroutine ("FadeIn", level);
	}

	public void StartFadeOut(){
		StartCoroutine ("FadeOut");
	}

	IEnumerator FadeIn(string level){
		fadePanel.SetActive (true);
		anim.Play ("FadiIn");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(level);
	}

	IEnumerator FadeOut(){
		anim.Play ("FadeOut");
		yield return new WaitForSeconds(1f);
		fadePanel.SetActive (false);
	}
}
