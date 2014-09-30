using UnityEngine;
using System.Collections;

public class PowerUpBox : MonoBehaviour {

	char gun;
	public GameObject powerUp;
	public int powerup=0;

	// Use this for initialization
	void Start () {
		gun=mapping();
	}
	
	// Update is called once per frame
	void Update () {}

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
	
	
}
