using UnityEngine;
using System.Collections;

public class bridgeBoom : MonoBehaviour {

	public GameObject bridge1;
	public GameObject bridge2;
	public GameObject bridge3;
	public GameObject bridge4;

	public float bridgeTiming=0.2f;

	float timePassed=0f;

	public bool boomed=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(boomed)
		{
			timePassed+=Time.deltaTime;
			if(timePassed>bridgeTiming)
			{
				if(bridge1) {
					Destroy(bridge1);
				}
				else if(bridge2) Destroy(bridge2);
				else if(bridge3) Destroy(bridge3);
				else if(bridge4) Destroy(bridge4);
				else Destroy(this.gameObject);
				timePassed=0;
			}
		}
	}


}
