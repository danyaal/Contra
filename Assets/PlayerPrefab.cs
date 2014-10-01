using UnityEngine;
using System.Collections;

public class PlayerPrefab : MonoBehaviour {
	public Vector3		Velocity = Vector3.zero;
	public float		Gravity	=	9.81f;
	public float 		walkSpeed= 7f;
	public char gun ='q';

	public GameObject Bullet;
	public GameObject Blimp;
	public GameObject Laser1;
	public GameObject Laser3;
	public GameObject Laser2;
	public GameObject SpinBullet;


	//machineGun Flags
	float timePassed=0;
	public int BulletsOnScreen=0;
	public float MachineGunRateOfFire=0.3f;

	//flags all over this bitch

	public bool			leftFlag=false; 
	public bool			rightFlag=false;
	public bool 		upFlag=false;
	public bool			downFlag = false;
	public int 			facing =1;
	public bool 		forcefall = false;
	public bool			shootFlag = false;
	public bool 		wallFlag=false;

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

	void shootlas (Vector3 axis)
	{
		if (Laser1)
						Destroy (Laser1);
		if (Laser3)
			Destroy (Laser3);
		if (Laser2)
			Destroy (Laser2);
		Laser1 =Instantiate(Bullet) as GameObject;
		Laser2 =Instantiate(Bullet) as GameObject;
		Laser3 =Instantiate(Bullet) as GameObject;
		Vector3 l1p = this.transform.position;
		Vector3 l2p = this.transform.position;
		l2p.x += axis.normalized.x * 0.08f;
		
		l2p.y += axis.normalized.y * 0.08f;
		Vector3 l3p = this.transform.position;
		l3p.x += axis.normalized.x * 0.16f;
		
		l3p.y += axis.normalized.y* 0.16f;
		Laser1.transform.position = l1p;
		Laser2.transform.position = l2p;
		
		Laser3.transform.position = l3p;
		
		Bullet bScript1 = Laser1.GetComponent<Bullet>();
		
		Bullet bScript2 = Laser2.GetComponent<Bullet>();
		
		Bullet bScript3 = Laser3.GetComponent<Bullet>();
		bScript1.Release(axis, true, laser:true);
		bScript2.Release(axis, true, laser:true);
		bScript3.Release(axis, true, laser:true);
	}

	void shoot(Vector3 axis)
	{


			GameObject bullet = Instantiate(Bullet) as GameObject;
			bullet.transform.position=this.transform.position;
		Bullet bScript = bullet.GetComponent<Bullet>();
		BulletsOnScreen += 1;
		bScript.Release(axis, true);
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

		if (Input.GetKeyDown(".")&& !floating){
			if(!InWater){
				if(crouchFlag)
					{floating=true;
					forcefall=true;}
				else
					{spindrive=true;}
			}
		}

		if(Input.GetKeyDown(",")&&gun!='m') {

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
			if((BulletsOnScreen<10&&gun=='s'))
				spreadShoot(vec);
			if((BulletsOnScreen<4&&gun=='q')||(BulletsOnScreen<5&&gun=='r'))
				shoot (vec);
			if(gun=='l')
				shootlas(vec);
		}

		if (Input.GetKey (",") && gun == 'm') {
			//MACHINE GUN FUNK
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
			if(timePassed==0||timePassed>=MachineGunRateOfFire)
			{
				shoot (vec);
				timePassed=0;
			}
			timePassed+=Time.deltaTime;
			
				}

		if (Input.GetKeyUp (",")) {
			timePassed=0;
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
			Velocity.y=20f;
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
				if(!wallFlag)
					Velocity.x=walkSpeed*1;
				else Velocity.x=0;
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
				if(!wallFlag)
					Velocity.x=walkSpeed*1;
				else Velocity.x=0;

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
		if(col.CompareTag("bridgeBoom"))
		{
			bridgeBoom bb=col.gameObject.GetComponent<bridgeBoom>();
			bb.boomed=true;
		}
		if (col.CompareTag ("wall")) {
			wallFlag=true;		
		
		}
		if(!col.CompareTag("Jump")){
		if (col.CompareTag ("Bullet")) {
			Bullet bull;
			bull=col.gameObject.GetComponent<Bullet>();
			if(!bull.IsPlayer()&&(!crouchFlag||!InWater)){Destroy(col.gameObject);
					if(contraScript){contraScript.KillThePlayer();}
					else {OtherContra contsc= Camera.main.gameObject.GetComponent<OtherContra>();
						contsc.KillThePlayer();}
				}
				} else if (col.CompareTag ("Villan")) {
				if(contraScript){contraScript.KillThePlayer();}
				else {OtherContra contsc= Camera.main.gameObject.GetComponent<OtherContra>();
					contsc.KillThePlayer();}
				} else if(col.CompareTag("PowerupTrig"))
			          {
				Debug.Log ("here");
				GameObject trig = col.gameObject;
				BlimpSpawn bs = trig.GetComponent<BlimpSpawn>();
				if(bs.guiInstantiated)
				{
					Vector3 initPos=Vector3.zero;
					initPos.y=bs.ycoord;
					GameObject blimpy = Instantiate (Blimp) as GameObject;
					Vector3 fun=Camera.main.ViewportToWorldPoint(initPos);
					fun.z=0;
					blimpy.transform.position=fun;
					PowerUpBlimp pub= blimpy.GetComponent<PowerUpBlimp>();
					pub.gun=bs.pch;
					pub.yi=blimpy.transform.position.y;
				}
				else{
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

					}}
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
		if (col.CompareTag ("wall"))
						wallFlag = false;

		if(!col.CompareTag("Bullet")&&!col.CompareTag("Villan")&&!col.CompareTag("PowerupTrig")){
			collidingWith--;

				if(collidingWith==0&&!crouchFlag) {
						floating = true;
						airLeft = leftFlag;
						airRight = rightFlag;
			}
		}
	}
	void spreadShoot(Vector3 axis)
	{
		Vector3 axup1 = Vector3.zero;
		Vector3 axup2 = Vector3.zero;
		Vector3 axdown1 = Vector3.zero;
		Vector3 axdown2 = Vector3.zero;

		if (axis.x == 1 && axis.y == 1) {
						axup1.y = Mathf.Sqrt (2);	
						axup1.x = 1;
						axup2.y = Mathf.Sin(Mathf.Deg2Rad*75);
						axup2.x=Mathf.Cos (Mathf.Deg2Rad*75);
						axdown2.x =Mathf.Cos (Mathf.Deg2Rad*15);
			axdown2.y=Mathf.Sin (Mathf.Deg2Rad*15);
						axdown1.x = Mathf.Sqrt (2);
						axdown1.y = 1;
				} else if (axis.x == -1 && axis.y == -1) {
			axup1.x = -Mathf.Sqrt (2);	
			axup1.y = -1;
			axup2.x = Mathf.Cos(Mathf.Deg2Rad*195);
			axup2.y = Mathf.Sin(Mathf.Deg2Rad*195);
			axdown2.y = Mathf.Sin(Mathf.Deg2Rad*255);
			axdown2.x = Mathf.Cos(Mathf.Deg2Rad*255);
			axdown1.y = -Mathf.Sqrt (2);
			axdown1.x = -1;
		}else if (axis.x == -1 && axis.y == 1) {
			axup1.y = Mathf.Sqrt (2);	
			axup1.x = -1;
			axup2.y = Mathf.Sin(Mathf.Deg2Rad*105);
			axup2.x=Mathf.Cos(Mathf.Deg2Rad*105);
			axdown2.x = Mathf.Cos(Mathf.Deg2Rad*165);
			axdown2.y =Mathf.Sin(Mathf.Deg2Rad*165);
			axdown1.x = -Mathf.Sqrt (2);
			axdown1.y = 1;
		}else if (axis.x == 1 && axis.y == -1) {
			axup1.x = Mathf.Sqrt (2);	
			axup1.y = -1;
			axup2.x = Mathf.Cos(-Mathf.Deg2Rad*15);
			axup2.y= Mathf.Sin(Mathf.Deg2Rad*-15);
			axdown2.y = Mathf.Sin(Mathf.Deg2Rad*-75);
			axdown2.x=Mathf.Cos(Mathf.Deg2Rad*-75);
			axdown1.y = -Mathf.Sqrt (2);
			axdown1.x = 1;
		}else if (axis.x == -1) {
			axup1.x = -Mathf.Sqrt (2);	
			axup1.y = 1;
			axup2.x = Mathf.Cos(Mathf.Deg2Rad*165);
			axup2.y=Mathf.Sin(Mathf.Deg2Rad*165);
			axdown2.y = Mathf.Sin(Mathf.Deg2Rad*205);;
			axdown2.x=Mathf.Cos(Mathf.Deg2Rad*205);
			axdown1.x = -Mathf.Sqrt (2);
			axdown1.y = -1;
		}else if (axis.y == -1) {
			axup1.y = -Mathf.Sqrt (2);	
			axup1.x = -1;
			axup2.x = Mathf.Cos(Mathf.Deg2Rad*285);
			axup2.y=Mathf.Sin(Mathf.Deg2Rad*285);
			axdown2.y = Mathf.Sin(Mathf.Deg2Rad*255);
			axdown2.x=Mathf.Cos(Mathf.Deg2Rad*255);
			axdown1.y = -Mathf.Sqrt (2);
			axdown1.x = 1;
		}else if (axis.x == 1) {
			axup1.x = Mathf.Sqrt (2);	
			axup1.y = 1;
			axup2.x = Mathf.Cos(Mathf.Deg2Rad*15);
			axup2.y=Mathf.Sin(Mathf.Deg2Rad*15);
			axdown2.y = Mathf.Sin(Mathf.Deg2Rad*-15);
			axdown2.x=Mathf.Cos(Mathf.Deg2Rad*-15);
			axdown1.x = Mathf.Sqrt (2);
			axdown1.y = -1;
		}else if (axis.y == 1) {
			axup1.y = Mathf.Sqrt (2);	
			axup1.x = -1;
			axup2.x = Mathf.Cos(Mathf.Deg2Rad*75);
			axup2.y=Mathf.Sin(Mathf.Deg2Rad*75);
			axdown2.y = Mathf.Sin(Mathf.Deg2Rad*105);
			axdown2.x=Mathf.Cos(Mathf.Deg2Rad*105);
			axdown1.y = Mathf.Sqrt (2);
			axdown1.x = 1;
		}

		shoot (axis);
		shoot (axup1);
		shoot (axup2);
		shoot (axdown1);
		shoot (axdown2);
		
	}
	
	
}
