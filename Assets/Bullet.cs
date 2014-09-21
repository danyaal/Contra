using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Vector3 VelocityAxis;
	bool playerOwned;
	bool released=false;
	public float Speed = 6f;

	// Use this for initialization
	void Start () {
		// cont= Camera.main.GetComponent<Contra>();
		Vector3 pos = GameObject.Find ("Gun").transform.position;
		pos.x = pos.x+1.1f;
		this.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		if (released) 
		{
			Vector3 pos = transform.position;
			pos.x += Speed * Time.deltaTime;
			transform.position = pos;
			if(Camera.main.WorldToViewportPoint(pos).x<0f ||
			   Camera.main.WorldToViewportPoint(pos).y<0f ||
			   Camera.main.WorldToViewportPoint(pos).x>1f ||
			   Camera.main.WorldToViewportPoint(pos).y>1f) {
				Destroy(this.gameObject);
			}
		}

	}

	public void Release(Vector3 axis, bool po)
	{
			VelocityAxis = axis.normalized;
			playerOwned = po;
			released = true;
	}

	public bool IsPlayer(){
				return playerOwned;
		}

}
