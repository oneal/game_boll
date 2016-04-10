using UnityEngine;
using System.Collections;

public class UltimoTiempo : MonoBehaviour {
	static public string score = "0";
	// Use this for initialization
	void Start () {
		score=PlayerPrefs.GetString("tiempo");
	}
	
	// Update is called once per frame
	void Update () {
		GUIText gt = this.GetComponent<GUIText>();
		if(Screen.width>=1024){
			gt.fontSize=20;
		}
		if(Screen.width>=500 && Screen.width<1024){
			gt.fontSize=15;
		}
		
		if(Screen.width>=100 && Screen.width<500){
			gt.fontSize=10;
		}
		gt.text = "Ultimo Tiempo: "+score+"";
	}
}
