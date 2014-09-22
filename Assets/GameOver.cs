using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public float i = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if(i >= 2) {
			Application.LoadLevel("_1-1Intro");
		}
		i += Time.deltaTime;
	}
}