using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTypeControl : MonoBehaviour {
	

	public void ChangeWorldType(){
		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");

		if(GlobalData.Instance.worldType){
			GlobalData.Instance.worldType = false;
			foreach (GameObject item in backgrounds){
				item.GetComponent<SpriteRenderer>().color = Color.red;
			}
		}else{
			GlobalData.Instance.worldType = true;
			foreach (GameObject item in backgrounds){
				item.GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}
}
