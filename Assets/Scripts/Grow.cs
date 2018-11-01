using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {
	bool isGrowing = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void growUp(){
		GlobalData data = GlobalData.Instance;
		if(data.growingPlant.Count >= data.MaxPlantNum){
			GameObject diePlant = data.growingPlant.Dequeue();
			data.growingPlant.Enqueue(this.gameObject);
			diePlant.GetComponent<Grow>().dieDown();
		}

		Vector3 position =  this.gameObject.transform.position;
		position.y += 2;
		this.gameObject.transform.Translate(new Vector3(0,2,0));
	}

	public void dieDown(){
		this.gameObject.transform.Translate(new Vector3(0,-2,0));
	}

}
