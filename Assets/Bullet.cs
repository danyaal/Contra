using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Vector3 VelocityAxis;
	bool playerOwned;
	bool released=false;
	public float Speed = 3f;

	// Use this for initialization
	void Start () {
		cont= Camera.main.GetComponent<Contra>();
	}
	
	// Update is called once per frame
	void Update () {
		if (released) 
		{
				Vector3 pos = transform.position;
				pos += VelocityAxis * Speed*Time.deltaTime;
				transform.position=pos;
			// if(Camera.main.WorldToScreenPoint(pos).y<-1)
		}

	}

	public void Release(Vector3 axis, bool po)
	{
			VelocityAxis = axis;
			playerOwned = po;
			released = true;
	}

}
