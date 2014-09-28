using UnityEngine;
using System.Collections;

public class PlayerPrefab : MonoBehaviour {
	public Vector3		Velocity = Vector3.zero;
	public float		Gravity	=	9.81f;
	public float 		walkSpeed= 3f;
	public char gun ='q';

	public GameObject Bullet;
	public GameObject Blimp;

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
	public bool 		lastSetLeft=false;
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

	void shoot(Vector3 axis)
	{

		//switch(gun)
		//{

		//case 'q':
		//case 'r':
			GameObject bullet = Instantiate(Bullet) as GameObject;
			bullet.transform.position=this.transform.position;
			Bullet bScript = bullet.GetComponent<Bullet>();
			bScript.Release(axis, true);
		//}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("a")) {
			leftFlag=true;
			airLeft=true;
			if(!rightFlag) {
				airRight=false;
			}
			lastSetLeft = true;

			// Change direction of gun
			Vector3 playerpos = this.transform.position;
			Vector3 pos = GameObject.Find("Gun").transform.position;
			pos.x = playerpos.x - System.Math.Abs(pos.x - playerpos.x);
			GameObject.Find("Gun").transform.position = pos;
			/*Quaternion rot = GameObject.Find("Gun").transform.rotation;
			rot.z = System.Math.Abs (rot.z) * -1;
			GameObject.Find("Gun").transform.rotation = rot;*/
		}
		if (Input.GetKeyDown("d")){
			rightFlag=true;
			airRight=true;
			if(!leftFlag) {
				airLeft=false;
			}
			lastSetLeft = false;

			// Change direction of gun
			Vector3 playerpos = this.transform.position;
			Vector3 pos = GameObject.Find("Gun").transform.position;
			pos.x = System.Math.Abs(pos.x - playerpos.x) + playerpos.x;
			GameObject.Find("Gun").transform.position = pos;
			/*m.Math.Abs(rot.z);
			GameObject.Find("Gun").transform.rotation = rot;*/
		}
		if (Input.GetKeyDown("w")){
			upFlag=true;
			/*Quaternion rot = GameObject.Find("Gun").transform.rotation;
			rot.z = 0;
			GameObject.Find("Gun").transform.rotation = rot;*/
		}
		if (Input.GetKeyDown("s")){
			downFlag=true;
			/*Quaternion rot = GameObject.Find("Gun").transform.rotation;
			rot.z = 270;
			GameObject.Find("Gun").transform.rotation = rot;*/
		}

		if (Input.GetKeyDown(",")&& !floating){
			if(!InWater){
				if(crouchFlag)
					{floating=true;
					forcefall=true;}
				else
					{spindrive=true;}
			}
		}

		if(Input.GetKeyDown(".")) {

			Vector3 vec = Vector3.zero;
			// Figure out direction to send bullet
			if(upFlag && 
			   rightFlag) {
				vec.x = 1;
				vec.y = 1;
			} else if(rightFlag && 
			          downFlag) {
				vec.x = 1;
				vec.y = -1;
			} else if(downFlag && 
			          leftFlag) {
				vec.x = -1;
				vec.y = -1;
			} else if(leftFlag && 
			          upFlag) {
				vec.x = -1;
				vec.y = 1;
			} else if(upFlag) {
				vec.y = 1;
			} else if(rightFlag) {
				vec.x = 1;
			} else if(downFlag &&
			          floating) {
				vec.y = -1;
			}  else if(leftFlag) {
				vec.x = -1;
			} else {
				if(lastSetLeft) {
					vec.x = -1;
				} else {
					vec.x = 1;
				}
			}
			shoot (vec);
		}




		if (Input.GetKeyUp ("a")) {
			leftFlag=false;
			if(airRight|| !floating){
				airLeft=false;
			}
		}
		if (Input.GetKeyUp("d")){
			rightFlag=false;
			if(leftFlag|| !floating)
			{airRight=false;}
		}
		if (Input.GetKeyUp("w")){
			upFlag=false;
		}
		if (Input.GetKeyUp("s")){
			downFlag=false;
		}


	}
	void FixedUpdate()
	{
		Vector3 pos = transform.position;
		if (spindrive) {
			Velocity.y=15f;
			floating=true;
			spindrive=false;
		}
		if (floating) {
			Velocity.y-=Gravity*2*Time.deltaTime;
			if(crouchFlag)
			{
				if(!InWater)
				{pos.y+=1.5f;
					transform.Rotate(Vector3.forward, 90f*facing);}
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
					if(!InWater)
					{pos.y+=1.5f;
						transform.Rotate(Vector3.forward, 90f*facing);}
					crouchFlag=false;}
				facing=1;
			}
			else if(leftFlag)
			{
				Velocity.x=walkSpeed*-1;

				if(crouchFlag)
				{
					if(!InWater){
					pos.y+=1.5f;
						transform.Rotate(Vector3.forward, 90f*facing);}
					crouchFlag=false;
					}
				facing=-1;
			}
			else
			{
				if(downFlag)
				{
					if(!crouchFlag){crouchFlag=true;
						if(!InWater){
					transform.Rotate (Vector3.forward, -90f*facing);
							pos.y-=1.5f;}}
				}
				else if(crouchFlag)
				{
						if(!InWater)
						{pos.y+=1.5f;
							transform.Rotate(Vector3.forward, 90f*facing);}
					crouchFlag=false;
					}
				Velocity.x=0;
			}
		}
		if(!downFlag&&crouchFlag)
		{
			if(!InWater)
			{pos.y+=1.5f;
				transform.Rotate(Vector3.forward, 90f*facing);}
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
		if(!col.CompareTag("Jump")){
		if (col.CompareTag ("Bullet")) {
			Bullet bull;
			bull=col.gameObject.GetComponent<Bullet>();
			if(!bull.IsPlayer()&&(!crouchFlag||!InWater)){Destroy(col.gameObject);
				contraScript.KillThePlayer();}
				} else if (col.CompareTag ("Villan")) {
						contraScript.KillThePlayer();
				} else if(col.CompareTag("PowerupTrig"))
			          {
				Debug.Log ("here");
				GameObject trig = col.gameObject;
				BlimpSpawn bs = trig.GetComponent<BlimpSpawn>();
				for(int i=0; i<bs.yViewportCoords.Count; i++)
				{
					Vector3 initPos=Vector3.zero;
					Debug.Log (i);
					initPos.y=(float)bs.yViewportCoords[i];
					Debug.Log (initPos.y);
					GameObject blimpy = Instantiate (Blimp) as GameObject;
					Vector3 fun=Camera.main.ViewportToWorldPoint(initPos);
					fun.z=0;
					blimpy.transform.position=fun;
					PowerUpBlimp pub= blimpy.GetComponent<PowerUpBlimp>();
					pub.gun=(char)bs.types[i];
					Debug.Log (pub.gun);
					pub.yi=blimpy.transform.position.y;

				}
				Destroy(trig);
			}


			else {
			collidingWith++;
						if(col.CompareTag("Water"))
			   			{
							floating = false;
							airLeft = false;
							airRight = false;
							Velocity.y = 0;
							Vector3 pos = transform.position;
							pos.y = col.bounds.max.y + transform.localScale.y + 0.2f;
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
	}

	void OnTriggerExit(Collider col)
	{
		if(!col.CompareTag("Bullet")&&!col.CompareTag("Villan")&&!col.CompareTag("PowerupTrig")){
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
