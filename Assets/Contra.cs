using UnityEngine;
using System.Collections;

public class Contra : MonoBehaviour {

	public GameObject GroundPrefab;

	// Use this for initialization
	void Start () {
		GameObject ground = Instantiate (GroundPrefab) as GameObject;
		Vector3 pos = Vector3.zero;
		pos.x = 16.67159f;
		pos.y = -2.252744f;
		pos.z = 0f;
		ground.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
