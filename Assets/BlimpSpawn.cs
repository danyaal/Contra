using UnityEngine;
using System.Collections;

public class BlimpSpawn : MonoBehaviour {

	public ArrayList yViewportCoords;
	public ArrayList types;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{

		}
}
