using UnityEngine;
using System.Collections;

public class innerWeapon : MonoBehaviour {

	public GameObject parent;
	public GameObject bulletPrefab;
	public Vector3 muzzle;
	public int ammunition;
	public int speed;
	public float rateOfFire;

	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
		ammunition = parent.GetComponent<status>().ammunition;
	}
	
	// Update is called once per frame
	void Update () {

		ammunition = parent.GetComponent<status>().ammunition;
	}

	void FireBullet(){
		if(ammunition > 0){
			GameObject bullet = (GameObject)Instantiate(bulletPrefab,transform.position,transform.rotation);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2((transform.up * speed).x,(transform.up * speed).y) + parent.GetComponent<Rigidbody2D>().velocity;
			parent.GetComponent<status>().ammunition--;
		}
	}

	public void Shoot(){
		InvokeRepeating("FireBullet", .001f, rateOfFire);
	}

	public void StopShoot(){
		CancelInvoke("FireBullet");
	}


}
