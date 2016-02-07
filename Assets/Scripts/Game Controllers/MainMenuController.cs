using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	private Animator animator;

	void Awake(){
		animator = GameObject.Find ("Menu Canvas").GetComponent<Animator> ();
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
		
	}
		
	public void OnQuitClick(){
		Application.Quit ();
	}
}
