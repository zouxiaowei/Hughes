using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {
	bool isGrowing = false;
	Vector3 initPosition;
	Vector3 endPosition;
	// Use this for initialization
	void Start () {
		
		initPosition = this.transform.position;
		endPosition = new Vector3 (initPosition.x, initPosition, y, initPosition.z);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isGrowing && transform.position.y < endPosition.y) {
			
			this.gameObject.transform.Translate (new Vector3 (0, 0.01, 0));

		} else if (isGrowing == false && transform.position.y > initPosition.y) {
			
			this.gameObject.transform.Translate (new Vector3 (0, -0.01, 0));
		} else {

			return;
		}

	}

	public void growUp(){
		GlobalData data = GlobalData.Instance;
		if(data.growingPlant.Count >= data.MaxPlantNum){
			
			GameObject diePlant = data.growingPlant.Dequeue();
			data.growingPlant.Enqueue(this.gameObject);
			diePlant.GetComponent<Grow>().dieDown();
		}
		this.isGrowing = true;

	}

	public void dieDown(){
		this.isGrowing = false;
	}

}
