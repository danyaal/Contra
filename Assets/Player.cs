using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Vector3		Velocity = Vector3.zero;
	public float		Gravity	=	10.81f;
	public float 		walkSpeed= 1.5f;

	//flags all over this bitch

	public bool			leftFlag=false; 
	public bool			rightFlag=false;
	public bool 		upFlag=false;
	public bool			downFlag = false;
	public int 			facing =1;
	public bool 		forcefall = false;

	public bool			crouchFlag = false;
	public bool 		floating = false;
	public bool			spindrive=false;
	public bool			airLeft = false;
	public bool 		airRight=false;
	public int 			collidingWith=0;
	public Camera cam=		Camera.main;
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
			if(crouchFlag)
			{floating=true;
				forcefall=true;}
			else
			{spindrive=true;}
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
			Velocity.y=11f;
			floating=true;
			spindrive=false;
		}
		if (floating) {
			Velocity.y-=Gravity*2*Time.deltaTime;
			if(crouchFlag)
			{
				pos.y+=1.3f;
				transform.Rotate(Vector3.forward, 90f*facing);
				crouchFlag=false;}
			if(airRight){
				Velocity.x=walkSpeed*1;
				facing=1;
			}
			else if(airLeft){
				Velocity.x=walkSpeed*-1;
				facing=-1;
			}
		} 
		else {
			if (rightFlag)
			{
				Velocity.x=walkSpeed*1;

				if(crouchFlag)
				{
					pos.y+=1.3f;
					transform.Rotate(Vector3.forward, 90f*facing);
					crouchFlag=false;}
				facing=1;
			}
			else if(leftFlag)
			{
				Velocity.x=walkSpeed*-1;

				if(crouchFlag)
				{
					pos.y+=1.3f;
					transform.Rotate(Vector3.forward, 90f*facing);
					crouchFlag=false;
					}
				facing=-1;
			}
			else
			{
				if(downFlag)
				{
					if(!crouchFlag){crouchFlag=true;
					transform.Rotate (Vector3.forward, -90f*facing);
						pos.y-=1.3f;}
				}
				else if(crouchFlag)
				{
					pos.y+=1.3f;
					transform.Rotate(Vector3.forward, 90f*facing);
					crouchFlag=false;
					}
				Velocity.x=0;
			}
		}
		if(!downFlag&&crouchFlag)
		{
			pos.y+=1.3f;
			transform.Rotate(Vector3.forward, 90f*facing);
			crouchFlag=false;
			}

		pos += Velocity * Time.deltaTime;
		transform.position = pos;
		Vector3 cpos = cam.transform.position;
		if ((rightFlag || airRight) && pos.x > cam.transform.position.x)
						cpos.x = pos.x;
		cam.transform.position = cpos;
	}
	void OnTriggerEnter(Collider col)
	{
		collidingWith++;
		if (col.CompareTag ("Bullet")) {
						Debug.Log ("BOOM");
				}
		if (Velocity.y < 0 && transform.position.y - transform.localScale.y > col.bounds.max.y&&!forcefall) {
						floating = false;
						airLeft = false;
						airRight = false;
						Velocity.y = 0;
						Vector3 pos = transform.position;
						pos.y = col.bounds.max.y + transform.localScale.y + 0.5f;
						transform.position = pos;
				} 
		else if(forcefall){forcefall=false;}
	}

	void OnTriggerExit(Collider col)
	{
		collidingWith--;

				if(collidingWith==0&&!crouchFlag) {
						floating = true;
						airLeft = leftFlag;
						airRight = rightFlag;
				}
	}
	void OnTriggerStay(Collider col)
	{

	}

	
}
