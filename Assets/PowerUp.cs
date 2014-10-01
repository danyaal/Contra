using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public char gun;
	bool midAir=true;
	public float Gravity=-9.81f;
	Vector3 velocity;

	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
		velocity.x = 5f;
		velocity.y = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (midAir) {
						velocity.y += Gravity * Time.deltaTime;
			transform.position+=velocity*Time.deltaTime;
				}

	}
	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("ground")) {
			midAir=false;
			velocity=Vector3.zero;
				}
		if(col.CompareTag("Player"))
		   {
			PlayerPrefab p =col.gameObject.GetComponentInParent<PlayerPrefab>();
			if(gun!='r')
				p.gun=gun;
			else if(p.gun=='q')
				p.gun=gun;
			Destroy(this.gameObject);
		}
	}
}
