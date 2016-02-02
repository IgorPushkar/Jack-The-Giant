using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;
	[SerializeField]
	private GameObject[] collectables;
	private float distanceBetweenClouds = 3f;
	private float minX, maxX;
	private float lastCloudY;
	private float controlX;
	private GameObject player;
}
