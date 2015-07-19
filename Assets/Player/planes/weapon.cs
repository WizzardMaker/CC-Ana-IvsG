using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	
	public Vector3[] ankerPointsOld = new Vector3[2];
	//Ankerpoints:
	//0 - left
	//1 - right
	public GameObject[] weaponsPrefab = new GameObject[1];
	//Weapons:
	//0 Machinegun
	public GameObject[] weapons = new GameObject[0];
	public int SelectedWeapon;

	// Use this for initialization
	void Start () {
		AddWeapon(0,0);
		AddWeapon(1,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			SelectedWeapon = 0;
			if(SelectedWeapon < weapons.Length && SelectedWeapon > -1){
				Shoot (SelectedWeapon);
			}
		}
		if (Input.GetButtonUp("Fire1")){
			StopShoot(0);
		}

		if (Input.GetButtonDown("Fire2")){
			SelectedWeapon = 1;
			if(SelectedWeapon < weapons.Length && SelectedWeapon > -1){
				Shoot (SelectedWeapon);//InvokeRepeating("Shoot", .001f, weapons[SelectedWeapon].transform.GetComponent<innerWeapon>().rateOfFire);
			}
		}

		if (Input.GetButtonUp("Fire2")){
			StopShoot(1);
		}
	}

	public void Shoot(int weapon){
		if(weapon < weapons.Length && weapon > -1){
			weapons[weapon].transform.GetComponent<innerWeapon>().Shoot();
		}
	}
	public void StopShoot(int weapon){
		if(weapon < weapons.Length && weapon > -1){
			weapons[weapon].transform.GetComponent<innerWeapon>().StopShoot();
		}
	}
	public void AddWeapon(int ankerpoint, int weapon){
		GameObject[] tempWeapons = new GameObject[weapons.Length];
		for(int i =0;i < weapons.Length;i++){
			tempWeapons[i] = weapons[i];
		}	

		weapons = new GameObject[weapons.Length + 1];

		for(int i =0;i < weapons.Length - 1;i++){
			weapons[i] = tempWeapons[i];
		}	

		Quaternion tempRot = new Quaternion();
		tempRot.y = ankerPointsOld[ankerpoint].x < 0 ? 0 : 180;

		GameObject newWeapon = (GameObject)Instantiate(weaponsPrefab[weapon],ankerPointsOld[ankerpoint],tempRot);

		newWeapon.transform.SetParent(transform);
		weapons[weapons.Length - 1] = newWeapon;
	}
}
