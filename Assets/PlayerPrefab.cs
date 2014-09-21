using UnityEngine;
using System.Collections;

public class PlayerPrefab : MonoBehaviour {
	public Vector3		Velocity = Vector3.zero;
	public float		Gravity	=	9.81f;
	public float 		walkSpeed= 3f;

	public GameObject Bullet;

	//flags all over this bitch

	public bool			leftFlag=false; 
	public bool			rightFlag=false;
	public bool 		upFlag=false;
	public bool			downFlag = false;
	public int 			facing =1;
	public bool 		forcefall = false;
	public bool			shootFlag = false;

	public bool			crouchFlag = false;
	public bool 		floating = false;
	public bool			spindrive=false;
	public bool			airLeft = false;
	public bool 		airRight=false;
	public bool 		InWater=false;
	public int 			collidingWith=0;
	public Camera 		cam;
	Contra contraScript;

	// Use this for initialization
	void Start () {
		floating = true;
		cam = Camera.main;
		contraScript = cam.GetComponent<Contra> ();
		Velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("left")) {
			leftFlag=true;
			airLeft=true;
			if(!rightFlag) {
				airRight=false;
			}

			// Change direction of gun
			Vector3 playerpos = GameObject.Find("PlayerPrefab").transform.position;
			Vector3 pos = GameObject.Find("Gun").transform.position;
			pos.x = playerpos.x - System.Math.Abs(pos.x - playerpos.x);
			GameObject.Find("Gun").transform.position = pos;
			Quaternion rot = GameObject.Find("Gun").transform.rotation;
			rot.z = System.Math.Abs (rot.z) * -1;
			GameObject.Find("Gun").transform.rotation = rot;
		}
		if (Input.GetKeyDown("right")){
			rightFlag=true;
			airRight=true;
			if(!leftFlag) {
				airLeft=false;
			}

			// Change direction of gun
			Vector3 playerpos = GameObject.Find("PlayerPrefab").transform.position;
			Vector3 pos = GameObject.Find("Gun").transform.position;
			pos.x = System.Math.Abs(pos.x - playerpos.x) + playerpos.x;
			GameObject.Find("Gun").transform.position = pos;
			Quaternion rot = GameObject.Find("Gun").transform.rotation;
			rot.z = System.Math.Abs(rot.z);
			GameObject.Find("Gun").transform.rotation = rot;
		}
		if (Input.GetKeyDown("up")){
			upFlag=true;
			Quaternion rot = GameObject.Find("Gun").transform.rotation;
			rot.z = 0;
			GameObject.Find("Gun").transform.rotation = rot;
		}
		if (Input.GetKeyDown("down")){
			downFlag=true;
			Quaternion rot = GameObject.Find("Gun").transform.rotation;
			rot.z = 270;
			GameObject.Find("Gun").transform.rotation = rot;
		}

		if (Input.GetKeyDown("a")&& !floating){
			if(!InWater){
				if(crouchFlag)
					{floating=true;
					forcefall=true;}
				else
					{spindrive=true;}
			}
		}

		if(Input.GetKeyUp("s")) {
			GameObject bullet = Instantiate(Bullet) as GameObject;
			//bullet.released(,true);
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

		if (col.CompareTag ("Bullet")) {
						Debug.Log ("BOOM");
			Bullet bull;
			bull=col.gameObject.GetComponent<Bullet>();
			if(!bull.IsPlayer()){Destroy(col.gameObject);
				contraScript.KillThePlayer();}
				} else if (col.CompareTag ("Villan")) {
						Debug.Log ("Bam");
						contraScript.KillThePlayer();
				} else {
			collidingWith++;
						if(col.CompareTag("Water"))
			   			{
							floating = false;
							airLeft = false;
							airRight = false;
							Velocity.y = 0;
							Vector3 pos = transform.position;
							pos.y = col.bounds.max.y + transform.localScale.y + 0.5f;
							transform.position = pos;
				InWater=true;
						}
						else if(InWater)
			{
				Vector3 pos = transform.position;
				pos.y = col.bounds.max.y + transform.localScale.y + 0.5f;
				if(facing==1)
				{pos.x=col.bounds.min.x;}
				else pos.x=col.bounds.max.x;
				InWater=false;
				transform.position = pos;
			}
						if (Velocity.y < 0 && transform.position.y - transform.localScale.y > col.bounds.max.y && !forcefall) {
								floating = false;
								airLeft = false;
								airRight = false;
								Velocity.y = 0;
								Vector3 pos = transform.position;
								pos.y = col.bounds.max.y + transform.localScale.y + 0.5f;
								transform.position = pos;
						} else if (forcefall) {
								forcefall = false;
						}
				}
	}

	void OnTriggerExit(Collider col)
	{
		if(!col.CompareTag("Bullet")&&!col.CompareTag("Villan")){
			collidingWith--;

				if(collidingWith==0&&!crouchFlag) {
						floating = true;
						airLeft = leftFlag;
						airRight = rightFlag;
			}
		}
	}
	void OnTriggerStay(Collider col)
	{

	}

	
}
