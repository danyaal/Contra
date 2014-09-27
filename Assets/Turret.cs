using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	float timePassed=0f;
	bool Shooting;
	public GameObject p;
	public GameObject bulletPrefab;
	float ShotzFired=0f;
	
	public bool onscreen = true;
	
	public bool playerAlive=true;
	public float timeBetweenBursts=5f;
	public float timeBetweenShots=.5f;
	public float ShotzMax=3f;
	public int hp = 3;

	// Use this for initialization
	void Start () {
		playerAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		p = GameObject.FindGameObjectWithTag ("Player");
		if (playerAlive) {
			timePassed += Time.deltaTime;
			if (timePassed >= timeBetweenBursts) {
				Shooting = true;
				PewPew ();
				timePassed = 0f;
			} else if (Shooting) {
				if (timePassed >= timeBetweenShots) {
					ShotzFired += 1f;
					PewPew ();
					timePassed = 0f;
				}
				if (ShotzFired >= ShotzMax - 1) {
					Shooting = false;
					ShotzFired = 0;
				}
			}
		}
	}

	void PewPew()
	{
		GameObject bullet = Instantiate (bulletPrefab) as GameObject;
		Vector3 bp=transform.position;
		bullet.transform.position = bp;
		
		Bullet bScript = bullet.GetComponent<Bullet> ();
		Vector3 ax = p.transform.position - bullet.transform.position;
		
		Vector3 axchex=ax.normalized;
		Vector3 bullAx=Vector3.zero;
		
		if(axchex.y<0.5f && axchex.y>-0.5f)
		{
			bullAx.y=0;
			bullAx.x=ax.x;
		}
		else if(axchex.y>0.5f && axchex.y<Mathf.Sqrt(3)/2f)
		{
			bullAx.y=Mathf.Sqrt(2)/2f;
			if(ax.x<0)
				bullAx.x=Mathf.Sqrt(2)/-2f;
			else {
				bullAx.x = Mathf.Sqrt(2)/2f;
			}
		}
		else if(axchex.y<-0.5f && axchex.y>Mathf.Sqrt(3)/-2f)
		{
			bullAx.y=Mathf.Sqrt(2)/-2f;
			if(ax.x<0)
				bullAx.x=Mathf.Sqrt(2)/-2f;
			else {
				bullAx.x=Mathf.Sqrt(2)/2f;
			}
		}
		else bullAx.y=ax.y;
		
		bScript.Release (bullAx, false);
		
	}
	
	public void ShitHesBack()
	{
		p = GameObject.FindGameObjectWithTag ("Player");
		playerAlive = true;
	}
	
	public void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Bullet")) {
			GameObject bgo=col.gameObject;
			Bullet bill =bgo.GetComponent<Bullet>();
			if(bill.IsPlayer()) {
				hp = hp - 1;
				Destroy(bgo);
				if(hp <= 0) {
					Destroy(this.gameObject);
				}
			}
		}
	}

}
