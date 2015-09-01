using UnityEngine;
using System.Collections;

public class MyShipColliderController : MonoBehaviour {

	public GameObject GameUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider cols){
		GameUI.SendMessage ("DamageShip");
	}
}
