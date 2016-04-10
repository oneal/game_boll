using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {
	private float speed=10f;
	private float salto=5f;
	private Vector3 fuerza;
	public static float saltospermitidos=0f;
	static public GUIText tiempoGT;
	static public GUIText ultimotiempoGT;


	// Use this for initialization
	void Start () {

		saltospermitidos = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (float.Parse (Tiempo.tiempo) < 1) {
			Tiempo.tiempo = "0" + (float.Parse (Tiempo.tiempo) + Time.deltaTime).ToString ("#.##");
		} else {
			Tiempo.tiempo = (float.Parse (Tiempo.tiempo) + Time.deltaTime).ToString ("#.##");
		}
		float dx = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;	
		Vector3 fuerza = new Vector3(dx,0,0);
		rigidbody.AddForce (fuerza,ForceMode.VelocityChange);
		//Debug.Log (transform.position.y + " " + GameObject.FindGameObjectWithTag ("MainCamera").transform.position.y);
		if (transform.position.y > GameObject.FindGameObjectWithTag ("MainCamera").transform.position.y+10) {

			if(float.Parse(Tiempo.tiempo)>float.Parse(UltimoTiempo.score)){
				UltimoTiempo.score=Tiempo.tiempo;
				PlayerPrefs.SetString("tiempo",UltimoTiempo.score);
			}
			Application.LoadLevel(0);
		}

		//if (transform.position.y > 11) {
		if (transform.position.y+15 < GameObject.FindGameObjectWithTag ("MainCamera").transform.position.y) {

			if(float.Parse(Tiempo.tiempo)>float.Parse(UltimoTiempo.score)){
				UltimoTiempo.score=Tiempo.tiempo;
				PlayerPrefs.SetString("tiempo",UltimoTiempo.score);
			}
			Application.LoadLevel (0);
		}

		//}
	 
		if(Input.GetKey(KeyCode.Space)){

			if(saltospermitidos<=60){
				rigidbody.velocity=Vector3.up*salto;
				saltospermitidos++;
			}
			//Debug.Log(saltospermitidos);

		}


	}

	void OnCollisionEnter(Collision otro){
		if (otro.gameObject.tag == "peldaño") {
			saltospermitidos=0;
		}
	}


	void OnTriggerEnter(Collider otro){
		if (otro.gameObject.tag == "cubo1") {
			//
			salto=salto+0.8f;
			Debug.Log("Salto "+salto);
			Destroy(otro.gameObject);
		}
		if (otro.gameObject.tag == "cubo2") {
			rigidbody.mass+=1f;
			Debug.Log("masa "+rigidbody.mass);
			Destroy(otro.gameObject);
		}

		if (otro.gameObject.tag == "cubo3") {			
			//Debug.Log("cubo3");
			speed=speed+0.5f;
			Debug.Log("velocidad "+speed);
			Destroy(otro.gameObject);
		}

		if (otro.gameObject.tag == "cubo4") {
			salto=salto-0.5f;
			//Debug.Log("cubo4");
			Destroy(otro.gameObject);
		}
		if (otro.gameObject.tag == "cubo5") {
			rigidbody.mass-=1f;
			//Debug.Log("cubo5");
			Destroy(otro.gameObject);
		}
		if (otro.gameObject.tag == "cubo6") {
			
			//Debug.Log("cubo6");
			Application.LoadLevel (0);
			Destroy(otro.gameObject);
			
		}
		
	}
}
