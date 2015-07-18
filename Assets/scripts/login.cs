using UnityEngine;
using System.Collections;

public class login : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GameJolt.UI.Manager.Instance.GetComponent<Canvas>().worldCamera = GetComponent<Camera>();
		GameJolt.UI.Manager.Instance.ShowSignIn((bool success) => {
			if (success){
				Application.LoadLevel(1);
				GameJolt.UI.Manager.Instance.QueueNotification("Loged in");
			}else{
				GameJolt.UI.Manager.Instance.QueueNotification("You need to login to play!");
				Application.LoadLevel(0);
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
