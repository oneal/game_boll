using UnityEngine;
using System.Collections;

public class Controlador : MonoBehaviour {
	private Vector3 posicionFinal;
	public GameObject peldaño;
	private float posiciony=0;
	public static ArrayList peldaños=new ArrayList();
	private float poscamara=0f;
	private float posultimopel=0f;
	public GameObject [] cubos;
	private float speed=1f;
	private float tiempo=0f;
	private float valorx=0;


	// Use this for initialization
	void Start () {

		tiempo = Time.deltaTime;
		posicionFinal = transform.position;
		crearPlataformas ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.position = GameObject.FindGameObjectWithTag("Player").transform.position+posicionFinal;
		tiempo++;
		if (tiempo > 600) {
			Debug.Log(speed);
			speed = speed + 0.80f;
			tiempo=0;
		}

		transform.Translate (0f, (speed * Time.deltaTime), 0f);
		GameObject ultimopeldaño = (GameObject) peldaños [peldaños.Count - 1];
		poscamara = transform.position.y;
		posultimopel = ultimopeldaño.transform.position.y;
		//Debug.Log ("Camara:"+pos+" ultimo peldaño:"+posultimopel);
		if(poscamara>posultimopel){
			Debug.Log("hola");
			crearPlataformas();
		}

	}

	public void crearPlataformas(){
		valorx = 0;

		Vector3 valor=camera.ScreenToWorldPoint(new Vector3(Screen.width,0,0));
		Debug.Log(Screen.width);


		for (int j = 0; j < 20; j++) {
			//cambiarValor(valorx);

			if(Screen.width>=1024){
				valorx = Random.Range (-(valor.x+10),(valor.x+10));
			}
			if(Screen.width>=500 && Screen.width<1024){
				valorx = Random.Range (-(valor.x+7),(valor.x+7));
			}
			
			if(Screen.width>=100 && Screen.width<500){
				valorx = Random.Range (-(valor.x+5),(valor.x+5));
			}
			GameObject pl = Instantiate (peldaño) as GameObject;
			posiciony+=(pl.transform.position.y+4);
			pl.transform.position=new Vector3(valorx,posiciony,0f);

			float valoraleat = Random.value;			
			if (valoraleat < 0.15f) {
				crearCubos(valorx,posiciony);
			}
			peldaños.Add(pl);
		}
	}

	public void crearCubos(float valorx,float posicion){
		int numcubo = 0;
		numcubo = Random.Range (1, 6);
		if (posiciony != 0) {
			GameObject cubo = Instantiate (cubos [numcubo]) as GameObject;
			cubo.transform.position = new Vector3 (valorx, (posicion + 2), 0f);
		}

	}
}
