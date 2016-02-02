using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	void Start(){
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		Vector3 newScale = transform.localScale;
		float width = renderer.sprite.bounds.size.x;
		float worldHeight = Camera.main.orthographicSize * 2f;
		float worldWidth = worldHeight * Screen.width / Screen.height;
		newScale.x = worldWidth / width;
		transform.localScale = newScale;
	}
}
