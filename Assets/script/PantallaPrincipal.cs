using UnityEngine;
using System.Collections;

public class PantallaPrincipal : MonoBehaviour {
	private Controlador c;
	private Vector3 posicionFinal;
	public GameObject peldaño;
	private float posiciony=0;
	public static ArrayList peldaños=new ArrayList();
	public GameObject [] cubos;
	public GameObject etiquetajugar;
	public GameObject etiquetasalir;


	// Use this for initialization
	void Start () {
		crearPlataformas ();

	}
	
	// Update is called once per frame
	void Update () {


		//crearPlataformas ();
		//Application.LoadLevel (0);

	}

	public void crearPlataformas(){
		float valorx = 0;
		
		for (int j = 0; j < 20; j++) {
			Debug.Log(transform.position.x);
			valorx = Random.Range (-10f,10f);
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
