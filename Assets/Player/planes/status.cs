using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class status : MonoBehaviour {
	
	public GameObject ui;
	public Transform healtbar;
	public Transform scoreText;
	public Transform waveText;
	public Transform ammunationText;
	public uint score;
	public short lives = 8;
	public int wave;
	public int ammunition = 100;
	public Sprite[] sprites = new Sprite[9];

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		healtbar = ui.transform.GetChild(0);
		if(lives > -1 && lives < 9){
			healtbar.GetComponent<Image>().sprite = sprites[lives];
		}

		scoreText = ui.transform.GetChild(1);
		scoreText.GetComponent<Text>().text = "Score: "  +  score.ToString();

		waveText = ui.transform.GetChild(2);
		waveText.GetComponent<Text>().text = "Wave: "  +  wave.ToString();

		ammunationText = ui.transform.GetChild(3);
		ammunationText.GetComponent<Text>().text = "Ammunation: "  +  ammunition.ToString();
	}
}
