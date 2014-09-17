using UnityEngine;
using System.Collections;

public class PlayerPrefab : MonoBehaviour {
	public Vector3		Velocity = Vector3.zero;
	public float		Gravity	=	9.81f;
	public float 		walkSpeed= 0.5f;

	//flags all over this bitch

	public bool			leftFlag=false;
	public bool			rightFlag=false;
	public bool 		upFlag=false;
	public bool			downFlag = false;

	public bool 		floating = false;
	public bool			spindrive=false;
	public bool			airLeft = false;
	public bool 		airRight=false;

	public Camera cam = Camera.main;


	// Use this for initialization
	void Start () {
		floating = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("left")) {
			leftFlag=true;
			airLeft=true;
			if(!rightFlag)
			{airRight=false;}
		}
		if (Input.GetKeyDown("right")){
			rightFlag=true;
			airRight=true;
			if(!leftFlag)
			{airLeft=false;}
		}
		if (Input.GetKeyDown("up")){
			upFlag=true;
		}
		if (Input.GetKeyDown("down")){
			downFlag=true;
		}

		if (Input.GetKeyDown("a")&& !floating){
			spindrive=true;
		}

		if (Input.GetKeyUp ("left")) {
			leftFlag=false;
			if(airRight|| !floating){
				airLeft=false;
			}
		}
		if (Input.GetKeyUp("right")){
			rightFlag=false;
			if(leftFlag|| !floating)
			{airRight=false;}
		}
		if (Input.GetKeyUp("up")){
			upFlag=false;
		}
		if (Input.GetKeyUp("down")){
			downFlag=false;
		}


	}
	void FixedUpdate()
	{
		Vector3 pos = transform.position;
		if (spindrive) {
			Velocity.y=10f;
			floating=true;
			spindrive=false;
		}
		if (floating) {
			Velocity.y-=Gravity*2*Time.deltaTime;
			if(airRight){
				Velocity.x=walkSpeed*10;
			}
			else if(airLeft){
				Velocity.x=walkSpeed*-10;
			}
		} 
		else {
			if (rightFlag)
			{
				Velocity.x=walkSpeed*10;
			}
			else if(leftFlag)
			{
				Velocity.x=walkSpeed*-10;
			}
			else
			{
				Velocity.x=0;
			}
		}
		pos += Velocity * Time.deltaTime;
		transform.position = pos;
		Vector3 cpos=cam.transform.position;
		if((rightFlag||airRight)&&pos.x>cpos.x)
		{
			cpos.x=pos.x;
			cam.transform.position=cpos;
		}
	}
	void OnTriggerEnter(Collider col)
	{
		floating = false;
		airLeft = false;
		airRight = false;
		Velocity.y = 0;
		Vector3 pos = transform.position;
		pos.y = col.bounds.max.y + transform.localScale.y+0.5f;
		transform.position = pos;
	}

	void OnTriggerExit(Collider col)
	{
		floating = true;
		airLeft = leftFlag;
		airRight = rightFlag;
	}
	void OnTriggerStay(Collider col)
	{

	}

	
}
