using UnityEngine;
using System.Collections;

public class baseTurret : MonoBehaviour {

	public GameObject gravityBullet;
	public float timeBetweenShots=0.5f;
	float timePassed=0f;
	int health = 7;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		timePassed += Time.deltaTime;
		if (timePassed <= 4) {
			FireAway();		
		}
	
	}

	void FireAway(){

		float speed=2f+Mathf.Floor(Random.value*4);
		Bullet Bill = gravityBullet.GetComponent<Bullet> ();
		Bill.GravityRelease (speed);

	}

	void onTriggerEnter(Collider col)
	{
		if(col.CompareTag("Bullet")) {
			GameObject bgo=col.gameObject;
			Bullet bill =bgo.GetComponent<Bullet>();
			if(bill.IsPlayer()) {
				health--;
				if(health==0)
					Destroy(this.gameObject);
				Destroy(bgo);
			}
		}
	}
	
}
