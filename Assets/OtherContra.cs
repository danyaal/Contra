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
			
			for (int i = 0; i < 200; ++i) {
				GameObject ground = Instantiate (GroundPrefab) as GameObject;
				Vector3 pos = Vector3.zero;
				pos.x = (2.6f * i) + -11;
				pos.y = -7f;
				ground.transform.position = pos;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject pgo = GameObject.Find ("PlayerPrefab");
		if (pgo) {
			Vector3 pos = pgo.transform.position;
			if (pos.x >= 500f) {
				Application.LoadLevel ("_1-1Intro");
			}
			if(pos.y <= -7f) {
				KillThePlayer();
			}
			Vector3 poop = Camera.main.transform.position;
			if(poop.x-(6.330409*2) > pos.x) {
				KillThePlayer();
			}
		}
		Vector3 camPos = Camera.main.transform.position;
		camPos.x += 5f*Time.deltaTime;
		Camera.main.transform.position = camPos;
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
