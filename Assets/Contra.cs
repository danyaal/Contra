using UnityEngine;
using System.Collections;


public class Contra : MonoBehaviour {
	public GameObject thePlayer;
	public GameObject playerPrefab;
	int Lives = 3;
	//ArrayList<GameObject> shootersOnScreen;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void KillThePlayer()
	{
		Debug.Log ("bam");
		Destroy (thePlayer);
		Lives--;
		if (Lives == 0) {
			Application.Quit();}
		//foreach(GameObject shot in shootersOnScreen)
		thePlayer = Instantiate (playerPrefab) as GameObject;
		Vector3 spawnpt = Vector3.zero;
		spawnpt.x = -0.6f;
		spawnpt.y = .6f;
		thePlayer.transform.position= Camera.main.ViewportToWorldPoint(spawnpt);
	}
}
