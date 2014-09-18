﻿using UnityEngine;
using System.Collections;

public class ShootBaddie : MonoBehaviour {
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
	// Use this for initialization
	void Start () {
		p = GameObject.Find ("Player");
		playerAlive = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
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
		bScript.Release (ax.normalized, false);

	}

	public void ShitHesBack()
	{
		p = GameObject.Find ("Player");
		playerAlive = true;
		}
	
}