using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float speed;
	public Camera cam;
	public Vector3 mousepos;
	public Vector3 objectpos;
	public float angle;
	public float angle2;
	public float velocity;
	public bool trueFalse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody2D rig = GetComponent<Rigidbody2D>();


		mousepos = Input.mousePosition;
		mousepos.z = 99.9f; //The distance between the camera and object
		objectpos = Camera.main.WorldToScreenPoint(transform.position);
		mousepos.x = mousepos.x - objectpos.x;
		mousepos.y = mousepos.y - objectpos.y;

		angle = FixAngle ( (Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg) - 90);
		angle2 = Mathf.DeltaAngle(angle,transform.eulerAngles.z);

		trueFalse = angle2 < 0 && angle2 > -180;

		if(angle2 < 0 && angle2 > -180){
			transform.Rotate (new Vector3(0,0, speed));
		}else{
			transform.Rotate (new Vector3(0,0,speed * -1)); //, transform.eulerAngles.z - speed < angle && transform.eulerAngles.z - speed > angle + 180 ? 0 : -1 * speed));
		}
		//transform.eulerAngles = (new Vector3(0, 0, angle - 90));

		//transform.rotation = Quaternion.Euler( new Vector3(0, 0, angle - 90) );

		rig.velocity = transform.up * velocity;
		// = mousepos;
	}

	float FixAngle (float angle){
		return angle < 0 ? 360 + angle : angle;
		
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
}
