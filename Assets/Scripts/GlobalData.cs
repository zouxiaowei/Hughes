using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {
	static GlobalData _instance;
	void Awake(){
		_instance = this;
		DontDestroyOnLoad (this.gameObject);
	}

	public static GlobalData Instance{
		get{
			return _instance;
		}

	}


	public bool worldType = false;
	public Queue<GameObject> growingPlant  = new Queue<GameObject>();
	public int MaxPlantNum = 3;

}
