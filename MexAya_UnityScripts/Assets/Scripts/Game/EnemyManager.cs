
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
	public static EnemyManager instance;
	public RectTransform UnidadesPanel;
	public GameObject cascada1;
	public GameObject cascada2;
	float speed;
	public bool juego,isMoving=true,isFiring=false;

	void Awake(){
		instance = this;
	}
	void Start() {
	}
	// Update is called once per frame
	void Update () {
		//setVisible(false);

	}
	public void IsMoving(bool _moving){
		isMoving = _moving;
	}
	public void IsFiring(bool _firing){
		isFiring = _firing;
	}
}
