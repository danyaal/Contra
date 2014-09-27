using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OtherContra : MonoBehaviour {
	public GameObject thePlayer;
	public bool spawnMap=true;
	public int Lives = 3;
	//ArrayList<GameObject> shootersOnScreen;
	
	public GameObject PlayerPrefab;
	public GameObject GroundPrefab;
	public GameObject BridgePrefab;
	public GameObject ShootBaddie;
	public GameObject WaterPrefab;
	public GameObject TurretPrefab;
	
	public GUIText livesGUI;
	
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("PlayerPrefab");
		if (spawnMap) {
			livesGUI = GameObject.Find("LivesLeft").GetComponent<GUIText>();
			livesGUI.guiText.text = "Lives: ooo";
			

		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject pgo = GameObject.Find ("PlayerPrefab");
		if (pgo) {
			Vector3 pos = pgo.transform.position;
			if (pos.x >= 249f) {
				Application.LoadLevel ("_2-2Intro");
			} else if(pos.y <= -7f) {
				KillThePlayer();
			}
		}
	}
	
	public void KillThePlayer()
	{
		Destroy (thePlayer);
		Lives--;
		livesGUI.text = livesGUI.text.Substring(0, livesGUI.text.Length-1);
		if (Lives <= 0) {
			Application.LoadLevel("_GameOver");
		}
		//foreach(GameObject shot in shootersOnScreen)
		thePlayer = Instantiate (PlayerPrefab) as GameObject;
		Vector3 spawnpt = Vector3.zero;
		spawnpt.x = 0.2f;
		spawnpt.y = 0.6f;
		Vector3 wspwn= Camera.main.ViewportToWorldPoint(spawnpt);
		wspwn.z = 0;
		thePlayer.transform.position = wspwn;
	}
}
