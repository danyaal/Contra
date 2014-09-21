using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Contra : MonoBehaviour {
	public GameObject thePlayer;
	public bool spawnMap=true;
	public int Lives = 3;
	//ArrayList<GameObject> shootersOnScreen;

	public GameObject PlayerPrefab;
	public GameObject GroundPrefab;
	public GameObject BridgePrefab;
	public GameObject ShootBaddie;

	// Use this for initialization
	void Start () {
				thePlayer = GameObject.Find ("PlayerPrefab");
				if (spawnMap){
		// Spawn Player
		// GameObject ground = Instantiate (PlayerPrefab) as GameObject;
		// First Ground area
						for (int i = 0; i < 23; ++i) {
								GameObject ground = Instantiate (GroundPrefab) as GameObject;
								Vector3 pos = Vector3.zero;
								pos.x = (2.6f * i) + -11;
								pos.y = 5f;
								ground.transform.position = pos;
						}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (5 * 2.6f);
						pos.y = 1f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (8 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (9 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (11 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (13 * 2.6f);
						pos.y = 1f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (19 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (20 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				// First Bridge
				for (int i = 0; i < 4; ++i) {
						GameObject bridge = Instantiate (BridgePrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (23 * 2.6f);
						pos.y = 5f;
						bridge.transform.position = pos;
				}
				// Middle Ground
				for (int i = 0; i < 5; ++i) {
						GameObject bridge = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (27 * 2.6f);
						pos.y = 5f;
						bridge.transform.position = pos;
				}
				// Next Bridge
				for (int i = 0; i < 4; ++i) {
						GameObject bridge = Instantiate (BridgePrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (32 * 2.6f);
						pos.y = 5f;
						bridge.transform.position = pos;
				}
				// Next Ground
				for (int i = 0; i < 8; ++i) {
						GameObject bridge = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (36 * 2.6f);
						pos.y = 5f;
						bridge.transform.position = pos;
				}
				for (int i = 0; i < 16; ++i) {
						GameObject bridge = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (42 * 2.6f);
						pos.y = 8f;
						bridge.transform.position = pos;
				}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (43 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (46 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 7; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (49 * 2.6f);
						pos.y = -2f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 6; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (53 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 7; ++i) {
						GameObject bridge = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (57 * 2.6f);
						pos.y = 5f;
						bridge.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (59 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (62 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 5; ++i) {
						GameObject bridge = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (63 * 2.6f);
						pos.y = 8f;
						bridge.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (65 * 2.6f);
						pos.y = -2f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (67 * 2.6f);
						pos.y = -1f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (70 * 2.6f);
						pos.y = 3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (73 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (73 * 2.6f);
						pos.y = -1f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (74 * 2.6f);
						pos.y = -4f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (77 * 2.6f);
						pos.y = 3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (78 * 2.6f);
						pos.y = 8f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (78 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (79 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (81 * 2.6f);
						pos.y = 3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 5; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (82 * 2.6f);
						pos.y = 3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (85 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (89 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 2; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (92 * 2.6f);
						pos.y = 3f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 7; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (94 * 2.6f);
						pos.y = -7f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 4; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (94 * 2.6f);
						pos.y = 5f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 3; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (95 * 2.6f);
						pos.y = -1f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (98 * 2.6f);
						pos.y = 0f;
						ground.transform.position = pos;
				}
				for (int i = 0; i < 1; ++i) {
						GameObject ground = Instantiate (GroundPrefab) as GameObject;
						Vector3 pos = Vector3.zero;
						pos.x = (2.6f * i) + -11 + (99 * 2.6f);
						pos.y = -3f;
						ground.transform.position = pos;
				}

			GameObject baddie = Instantiate (ShootBaddie) as GameObject;
			Vector3 pop = GameObject.Find ("PlayerPrefab").transform.position;
			pop.x = pop.x+10f;
			baddie.transform.position = pop;

			// TODO: SPAWN BADDIES
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void KillThePlayer()
	{
		Destroy (thePlayer);
		Lives--;
		if (Lives <= 0) {
			Debug.Log("xXxGaMeOvErXx");
			Application.Quit();}
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
