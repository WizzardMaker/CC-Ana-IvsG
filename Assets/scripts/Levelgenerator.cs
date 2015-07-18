using UnityEngine;
using System.Collections.Generic;

public class Levelgenerator : MonoBehaviour {

	public int amt_trees = 5;
	public int repeats = 1;
	public float min_size_x,min_size_y;
	public float max_size_x,max_size_y;
	public float x_offset,y_offset;
	public float debug;

	public GameObject tree;
	public GameObject groundPrefab;
	public GameObject player;
	public Playerfield ground;

	// Use this for initialization
	void Start () {
		max_size_x = 9f;
		min_size_x = -9f;
		max_size_y = 5f;
		min_size_y = -5f;
		x_offset = 20f;
		y_offset = 10.8f;

		ground = new Playerfield(Instantiate(groundPrefab));
		ground.z = 1;
		ground.UpdateGraphics();

		generateTrees(amt_trees);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		debug = player.transform.GetChild(0).transform.position.y;
		if(player.transform.GetChild(0).transform.position.y > max_size_y - 5){
			ground = new Playerfield(Instantiate(groundPrefab)); //,new Vector3(0,y_offset * repeats,1),transform.rotation);
			ground.x = 0;
			ground.y = y_offset * repeats;
			ground.z = 1;
			ground.UpdateGraphics();

			min_size_y = (y_offset * repeats) - (10.8f /2);
			max_size_y = (y_offset) * repeats + 5f;
			repeats++;
			generateTrees(amt_trees);
		}
	}

	void generateTrees(int amt){
		for (int i = 0; i < amt; i++) {
			Tree r = new Tree(Instantiate(tree));
			r.TreeGFX.transform.SetParent(ground.PlayerfieldGFX.transform);
			r.x = Random.Range((int)min_size_x,(int)max_size_x);
			r.y = Random.Range((int)min_size_y,(int)max_size_y);
			r.z = 1.7f;
			r.rotation = Random.Range(-180,180);
			r.UpdateGraphics();
		}
	}
}
public class Tree {
	
	public float x,y,z;
	public float height,width,length;
	public int rotation;
	
	public GameObject TreeGFX;

	
	public Tree(GameObject TreeGFX){
		this.TreeGFX = TreeGFX;
		height=1;
		width=1;
		length=1;
	}
	
	public bool Overlaps(Tree other){
		if(x < other.x+other.width && x+width > other.x &&
		   z < other.z+other.length && z+length > other.z){
			return true;
		}
		return false;
	}
	
	public void UpdateGraphics(){
		Vector3 pos = TreeGFX.transform.position;
		pos.x = x;
		pos.y = y;
		pos.z = z;
		TreeGFX.transform.position = pos;
		
		Vector3 scale = TreeGFX.transform.localScale;
		scale.x = width;
		scale.y = height;
		scale.z = length;
		TreeGFX.transform.localScale = scale;

		TreeGFX.transform.eulerAngles = new Vector3(0,0,rotation);
		
	}
}

public class Playerfield {
	
	public float x,y,z;
	public float height,width,length;
	public int rotation;
	
	public GameObject PlayerfieldGFX;
	
	
	public Playerfield(GameObject PlayerfieldGFX){
		this.PlayerfieldGFX = PlayerfieldGFX;
		height=1;
		width=1;
		length=1;
	}
	
	public bool Overlaps(Playerfield other){
		if(x < other.x+other.width && x+width > other.x &&
		   z < other.z+other.length && z+length > other.z){
			return true;
		}
		return false;
	}
	
	public void UpdateGraphics(){
		Vector3 pos = PlayerfieldGFX.transform.position;
		pos.x = x;
		pos.y = y;
		pos.z = z;
		PlayerfieldGFX.transform.position = pos;
		
		Vector3 scale = PlayerfieldGFX.transform.localScale;
		scale.x = width;
		scale.y = height;
		scale.z = length;
		PlayerfieldGFX.transform.localScale = scale;
		
		PlayerfieldGFX.transform.eulerAngles = new Vector3(0,0,rotation);
		
	}
}
