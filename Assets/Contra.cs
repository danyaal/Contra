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
	public GameObject WaterPrefab;
	public GameObject TurretPrefab;
	public GameObject runBaddie;
	public GameObject jumpPoint;
	public GameObject BaseDoor;

	public GUIText livesGUI;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("PlayerPrefab");
		if (spawnMap) {
			livesGUI = GameObject.Find("LivesLeft").GetComponent<GUIText>();
			livesGUI.guiText.text = "Lives: ooo";

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

			for (int i = 0; i < 9; ++i) {
				GameObject water = Instantiate (WaterPrefab) as GameObject;
				Vector3 pos = Vector3.zero;
				pos.x = (2.6f * i) + -11;
				pos.y = -7f;
				water.transform.position = pos;
			}
			for (int i = 0; i < 9; ++i) {
				GameObject water = Instantiate (WaterPrefab) as GameObject;
				Vector3 pos = Vector3.zero;
				pos.x = (2.6f * i) + -11 + (11 * 2.6f);
				pos.y = -7f;
				water.transform.position = pos;
			}
			for (int i = 0; i < 23; ++i) {
				GameObject water = Instantiate (WaterPrefab) as GameObject;
				Vector3 pos = Vector3.zero;
				pos.x = (2.6f * i) + -11 + (20 * 2.6f);
				pos.y = -7f;
				water.transform.position = pos;
			}
			for (int i = 0; i < 7; ++i) {
				GameObject water = Instantiate (WaterPrefab) as GameObject;
				Vector3 pos = Vector3.zero;
				pos.x = (2.6f * i) + -11 + (46 * 2.6f);
				pos.y = -7f;
				water.transform.position = pos;
			}

			GameObject baddie1 = Instantiate (ShootBaddie) as GameObject;
			Vector3 pop = Vector3.zero;
			pop.x = 13.51886f;
			pop.y = -4.956389f;
			baddie1.transform.position = pop;

			GameObject baddie2 = Instantiate (ShootBaddie) as GameObject;
			pop.x = 39.49377f;
			pop.y = -4.962969f;
			baddie2.transform.position = pop;

			GameObject baddie3 = Instantiate (ShootBaddie) as GameObject;
			pop.x = 88.86996f;
			pop.y = 7.066628f;
			baddie3.transform.position = pop;

			GameObject baddie4 = Instantiate (ShootBaddie) as GameObject;
			pop.x = 179.8854f;
			pop.y = 1.003429f;
			baddie4.transform.position = pop;

			GameObject turret1 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 86.48366f;
			pop.y = -0.1863329f;
			turret1.transform.position = pop;

			GameObject turret2 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 119.9455f;
			pop.y = 0.5918849f;
			turret2.transform.position = pop;

			GameObject turret3 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 132.5756f;
			pop.y = 0.5918849f;
			turret3.transform.position = pop;

			GameObject turret4 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 153.0279f;
			pop.y = -0.7118565f;
			turret4.transform.position = pop;

			GameObject turret5 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 163.4579f;
			pop.y = 10.044f;
			turret5.transform.position = pop;

			GameObject turret6 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 212.9445f;
			pop.y = 5.072047f;
			turret6.transform.position = pop;

			GameObject turret7 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 231.4367f;
			pop.y = -4.982932f;
			turret7.transform.position = pop;

			GameObject turret8 = Instantiate (TurretPrefab) as GameObject;
			pop.x = 241.7148f;
			pop.y = -4.982932f;
			turret8.transform.position = pop;

			GameObject runner1 = Instantiate (runBaddie) as GameObject;
			pop = Vector3.zero;
			pop.x = 13.51886f;
			pop.y = 7f;
			runner1.transform.position = pop;

			GameObject runner2 = Instantiate (runBaddie) as GameObject;
			pop = Vector3.zero;
			pop.x = 15.51886f;
			pop.y = 7f;
			runner2.transform.position = pop;

			GameObject runner3 = Instantiate (runBaddie) as GameObject;
			pop = Vector3.zero;
			pop.x = 17.51886f;
			pop.y = 7f;
			runner3.transform.position = pop;

			GameObject runner4 = Instantiate (runBaddie) as GameObject;
			pop = Vector3.zero;
			pop.x = 64.39999f;
			pop.y = 7f;
			runner4.transform.position = pop;

			GameObject runner5 = Instantiate (runBaddie) as GameObject;
			pop = Vector3.zero;
			pop.x = 67f;
			pop.y = 7f;
			runner5.transform.position = pop;

			GameObject runner6 = Instantiate (runBaddie) as GameObject;
			pop = Vector3.zero;
			pop.x = 69.6f;
			pop.y = 7f;
			runner6.transform.position = pop;

			GameObject runner7 = Instantiate (runBaddie) as GameObject;
			pop = Vector3.zero;
			pop.x = 116.4f;
			pop.y = 10f;
			runner7.transform.position = pop;

			GameObject based = Instantiate (BaseDoor) as GameObject;
			pop = Vector3.zero;
			pop.x = 252f;
			pop.y = -3f;
			based.transform.position = pop;

			// TODO: SPAWN BADDIES
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
