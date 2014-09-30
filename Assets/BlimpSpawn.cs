using UnityEngine;
using System.Collections;

public class BlimpSpawn : MonoBehaviour {

	public ArrayList yViewportCoords;
	public float ycoord=0.7f;
	public int powerup=0;
	public char pch;
	public ArrayList types;
	public bool guiInstantiated=false;
	public bool test=true;


	// Use this for initialization
	void Start () {
		yViewportCoords=new ArrayList();
		types= new ArrayList();
		if (test) {
			yViewportCoords.Add(0.5f);
			yViewportCoords.Add(0.7f);
			types.Add('s');
			types.Add ('r');
		}
		if(guiInstantiated)
			pch=mapping();

	}

	char mapping()
	{
		switch(powerup)
		{
		case 0:
			return 'r';
		case 1:
			return 's';
		case 2:
			return 'm';
		case 3:
			return 'l';
		default:
			return 's';
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{

		}
}
