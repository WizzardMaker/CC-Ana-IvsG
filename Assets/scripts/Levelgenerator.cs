using UnityEngine;
using System.Collections.Generic;

public class Levelgenerator : MonoBehaviour {

	public int amt_trees = 5;
	public int min_size_x,min_size_y;
	public int max_size_x,max_size_y;

	public GameObject tree;

	// Use this for initialization
	void Start () {
		max_size_x = 9;
		min_size_x = -9;
		max_size_y = 5;
		min_size_y = -5;

		for (int i = 0; i < amt_trees; i++) {
			Tree r = new Tree(Instantiate(tree));
			r.x = Random.Range(min_size_x,max_size_x);
			r.y = Random.Range(min_size_y,max_size_y);
			r.rotation = Random.Range(-180,180);
			r.UpdateGraphics();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
public class Tree {
	
	public int x,y,z;
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
