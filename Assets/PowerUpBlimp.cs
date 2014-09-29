using UnityEngine;
using System.Collections;

public class PowerUpBlimp : MonoBehaviour {


	public char gun;
	public GameObject powerUp;

	float t=0;
	public float freq = 4;
	public float yi;
	public float xSpeed=10f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
	{
		t += Time.deltaTime;
		Vector3 pos = transform.position;
		pos.y = yi + Mathf.Sin (freq * t);
		pos.x += xSpeed * Time.deltaTime;
		transform.position = pos;
		}

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Bullet"))
		   {
			GameObject bgo = col.gameObject;
			Bullet bill = bgo.GetComponent<Bullet>();
			if(bill.IsPlayer())
			{
				GameObject pup= Instantiate(powerUp) as GameObject;
				pup.transform.position=transform.position;
				PowerUp pu = pup.GetComponent<PowerUp>();
				pu.gun=gun;
				Destroy(bgo);
				Destroy(this.gameObject);
			}
		}
	}
}
