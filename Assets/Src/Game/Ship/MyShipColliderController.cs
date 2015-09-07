using UnityEngine;
using System.Collections;

public class MyShipColliderController : MonoBehaviour {

	public GameObject GameUI;

	void Awake(){
		this.gameObject.GetComponent<MeshRenderer> ().material.color = GlobalManager.shipColor;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider cols){
		if (cols.gameObject.tag == "EnemyMissle" || cols.gameObject.tag == "Asteroid") {
			GameUI.SendMessage ("DamageShip");
		}
	}
}
