using UnityEngine;
using System.Collections;

public class CustomLevelBaseDoor : MonoBehaviour {
	
	public int health=10;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
			Application.LoadLevel ("_1-1Intro");
		}
	}
	
	void onTriggerEnter(Collider col)
	{
		/*Debug.Log ("soup");
			if(col.CompareTag("Bullet")) {
				GameObject bgo=col.gameObject;
				Bullet bill =bgo.GetComponent<Bullet>();
				if(bill.IsPlayer()) {
					health--;
				if(health==0)
					Destroy(this.gameObject);
				Destroy(bgo);

				}
			}*/
	}
}
