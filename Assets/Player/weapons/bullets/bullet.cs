using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public float deathTime;

	// Use this for initialization
	void Start () {
		deathTime += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(deathTime < Time.time){
			Destroy(this.gameObject);
		}
	}
}
