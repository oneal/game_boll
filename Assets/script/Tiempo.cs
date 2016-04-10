using UnityEngine;
using System.Collections;

public class Tiempo : MonoBehaviour {
	static public string tiempo = "0";
	// Use this for initialization
	void Start () {
		tiempo = "0";

	}
	
	// Update is called once per frame
	void Update () {
		GUIText gt = this.GetComponent<GUIText>();
		if(Screen.width>=1024){
			gt.fontSize=20;
		}
		if(Screen.width>=500 && Screen.width<1024){
			gt.fontSize=16;
		}
		
		if(Screen.width>=100 && Screen.width<500){
			gt.fontSize=12;
		}

		gt.text = "Tiempo: "+tiempo+"";
	}
}
