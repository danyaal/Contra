using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Vector3 Velocity;
	bool playerOwned;
	bool released=false;
	bool grav=false;
	public float Gravity=-9.81f;
	public float SpeedInitial = 6f;

	// Use this for initialization
	void Start () {
		// cont= Camera.main.GetComponent<Contra>();
		//Vector3 pos = GameObject.Find ("Gun").transform.position;
		//pos.x = pos.x+1.1f;
		//this.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		if (released) 
		{
			Vector3 pos = transform.position;
			if(grav)
			{
				Vector3 acc=Vector3.zero;
				acc.y=Gravity;
				Velocity+=acc*Time.deltaTime;
			}

			pos += Velocity* Time.deltaTime;
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
			Velocity = axis.normalized*SpeedInitial;
			playerOwned = po;
			released = true;
	}

	public void GravityRelease(float iSpeed)
	{
		Velocity = Vector3.zero;
		SpeedInitial = iSpeed;
		Velocity.x = -1*iSpeed;
		grav = true;
		playerOwned = false;
		released = true;
		}

	public bool IsPlayer(){
				return playerOwned;
		}
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Door"))
		   {
			GameObject dgo = col.gameObject;
			BaseDoor bd=dgo.GetComponentInParent<BaseDoor>();
			bd.health--;
			Destroy(this.gameObject);
		}
	}

}
