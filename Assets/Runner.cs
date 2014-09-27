using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public float runSpeed=5f;
	public float jumpSpeed=10f;
	public float Gravity=9.81f;
	public float chanceToJump=0.3f;
	bool floating=false;
	Vector3 Velocity;
	// Use this for initialization
	void Start () {
		Velocity.x = runSpeed * -1;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){
		if (floating) {
			Vector3 acc=Vector3.zero;
			acc.y=Gravity*-1;
			Velocity+=acc*Time.deltaTime;
		}
		transform.position += Velocity * Time.deltaTime;

		}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("WOMP");
		if (col.CompareTag ("Jump")) {
			Debug.Log("shitass");
			if(!floating){
						if (Random.value <= chanceToJump) {
								Velocity.y = jumpSpeed;
								floating = true;
						} else
					Velocity.x *= -1;}
				} else if (col.CompareTag ("Bullet")) {
						GameObject bgo = col.gameObject;
						Bullet bill = bgo.GetComponent<Bullet> ();
						if (bill.IsPlayer ()) {
								Destroy (this.gameObject);
				Destroy(bgo);
						}
				} else if (!col.CompareTag ("Villan")) {
			if(floating)
			{
				floating=false;
				Velocity.y=0;
			}
				}
	}
}
