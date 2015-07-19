using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject player;
	public float speed;
	public Vector3 playerpos;
	public Vector3 objectpos;
	public float angle;
	public float angle2;
	public float velocity;
	public bool trueFalse;
	public float distance;
	public float minDistance;
	public string state;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		Rigidbody2D rig = GetComponent<Rigidbody2D>();
		
		playerpos = player.transform.position;
		objectpos = transform.position;
		distance = Vector3.Distance(playerpos,objectpos);
		playerpos.x = playerpos.x - objectpos.x;
		playerpos.y = playerpos.y - objectpos.y;

		
		angle = FixAngle ( (Mathf.Atan2(playerpos.y, playerpos.x) * Mathf.Rad2Deg) + 90);
		angle2 = Mathf.DeltaAngle(transform.eulerAngles.z,angle);
		
		trueFalse = angle2 < 0 && angle2 > -180;

		if(state != "evade"){
			if(distance < minDistance){
				state = "straight";
				if(!(FixAngle(transform.eulerAngles.z + 90) > angle) && !(FixAngle(transform.eulerAngles.z - 90) < angle)){
					state = "rotate";
				}
			}else{
				state = "rotate";
			}
		}
		switch(state){
			case("rotate"):
				if(angle2 < 0 && angle2 > -180){
					transform.Rotate (new Vector3(0,0, -1 * angle2 + speed > 179 ? 0 : speed));
				}else{
					transform.Rotate (new Vector3(0,0, -1 * angle2 + speed < -179 ? 0 : speed * -1)); //, transform.eulerAngles.z - speed < angle && transform.eulerAngles.z - speed > angle + 180 ? 0 : -1 * speed));
				}
			break;
			case("straight"):

			break;
			case("evade"):
				angle2 = Mathf.DeltaAngle(transform.eulerAngles.z,angle) + Random.Range(-90,90);

				if(angle2 < 0 && angle2 > -180){
					transform.Rotate (new Vector3(0,0, -1 * angle2 + speed > 179 ? 0 : speed));
				}else{
					transform.Rotate (new Vector3(0,0, -1 * angle2 + speed < -179 ? 0 : speed * -1)); //, transform.eulerAngles.z - speed < angle && transform.eulerAngles.z - speed > angle + 180 ? 0 : -1 * speed));
				}

			break;
		}
		//transform.eulerAngles = (new Vector3(0, 0, angle - 90));
		
		//transform.rotation = Quaternion.Euler( new Vector3(0, 0, angle - 90) );
		
		rig.velocity = transform.up * velocity;
		// = playerpos;
	}
	
	float FixAngle (float angle){
		if(angle < 0)
			return 360 + angle;
		if(angle > 360)
			return angle - 360;
		return angle;
		
	}
	
	bool CompareAngle(float angle1, float angle2){
		if(angle1 +180 > 360){
			if( ((angle1 + 180) - 360) > angle2 && angle1 < angle2 + 360){
				return true;
			}
			return false;
		}
		if(angle1 < angle2 && angle1 + 180 > angle2){
			return true;
		}
		return false;
	}
	void OnTriggerStay2D(Collider2D other) {

		state = "evade";
	}
	void OnTriggerExit2D(Collider2D other) {
		state = "rotate";
	}
	
}
