using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Contra : MonoBehaviour {

	public GameObject GroundPrefab;
	public GameObject PlayerPrefab;

	// Use this for initialization
	void Start () {
		// Spawn Player
		// GameObject ground = Instantiate (PlayerPrefab) as GameObject;
		// First Ground area
		for(int i = 0; i < 23; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11;
			pos.y = 5f;
			ground.transform.position = pos;
		}
		for(int i = 0; i < 3; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11+(5*2.6f);
			pos.y = 2f;
			ground.transform.position = pos;
		}
		for(int i = 0; i < 1; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11+(8*2.6f);
			pos.y = -1f;
			ground.transform.position = pos;
		}
		for(int i = 0; i < 2; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11+(9*2.6f);
			pos.y = -4f;
			ground.transform.position = pos;
		}
		for(int i = 0; i < 1; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11+(11*2.6f);
			pos.y = -1f;
			ground.transform.position = pos;
		}
		for(int i = 0; i < 3; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11+(13*2.6f);
			pos.y = 2f;
			ground.transform.position = pos;
		}
		for(int i = 0; i < 2; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11+(19*2.6f);
			pos.y = -4f;
			ground.transform.position = pos;
		}
		for(int i = 0; i < 3; ++i) {
			GameObject ground = Instantiate (GroundPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.x = (2.6f * i) + -11+(20*2.6f);
			pos.y = -1f;
			ground.transform.position = pos;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
