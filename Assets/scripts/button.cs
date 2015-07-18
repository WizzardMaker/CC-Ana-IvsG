using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class button : MonoBehaviour {

	public string Nname;
	public bool exit;
	public bool scoreboard;
	public bool play;
	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown() {

		if(exit){
			Application.Quit();
		}
		if(scoreboard){
			Application.LoadLevel(2);
		}
		if(play){
			Application.LoadLevel(3);
		}
		//Application.LoadLevel("SomeLevel");
	}
	// Update is called once per frame
	void Update () {

	}
}
