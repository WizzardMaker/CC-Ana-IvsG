using UnityEngine;
using System.Collections;

public class scoreboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameJolt.UI.Manager.Instance.GetComponent<Canvas>().worldCamera = GetComponent<Camera>();
		GameJolt.UI.Manager.Instance.ShowSignIn((bool success) => {
			if (success){
	    		Debug.Log("The user signed in!");
				GameJolt.UI.Manager.Instance.ShowLeaderboards((bool exit) => {
					if(exit){
					}else{
					Application.LoadLevel(0);
					}
				});
				GameJolt.UI.Manager.Instance.QueueNotification("WupWup");

			}else{
				Debug.Log("The user failed to signed in or closed the window :(");
				Application.LoadLevel(0);
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
