using UnityEngine;
using System.Collections;

public class follower : MonoBehaviour {

	public GameObject follow;
	public bool movable = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rig = GetComponent<Rigidbody2D>();

		if (movable) {
			rig.velocity = Vector3.up * (follow.transform.position.y - transform.position.y - 2f > 0 ? Mathf.Sign(follow.transform.position.y) : 0);
		}else{
			rig.velocity = Vector3.zero;
		}
	}
}
