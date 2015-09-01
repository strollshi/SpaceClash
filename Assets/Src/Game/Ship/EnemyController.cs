﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject Missle;

	private float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range(0.5f,1)*1;
		InvokeRepeating ("Launchinterval", 0, 4);
	}

	void Launchinterval(){
		InvokeRepeating ("LaunchMissle", 0, 0.2f);
		Invoke ("StopLaunch", 1);
	}

	void StopLaunch(){
		CancelInvoke ("LaunchMissle");
	}

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (0, 0, speed);
		if (this.gameObject.transform.position.z < -200) {
			Destroy(this.gameObject);
		}
	}

	private GameObject missle;

	public void LaunchMissle(){
		missle = Instantiate(Missle,new Vector3(transform.position.x,transform.position.y,transform.position.z),Missle.transform.rotation) as GameObject;
		missle.tag = "EnemyMissle";
		missle.GetComponent<MissleController> ().Direction = 1;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Missle") {
			Destroy(this.gameObject);
		}
	}

	public void DamageEnemyShip(){
		
	}
}
