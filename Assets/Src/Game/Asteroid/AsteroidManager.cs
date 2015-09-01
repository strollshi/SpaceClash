using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour {

	public GameObject myAsteroid_1;
	public GameObject myAsteroid_2;
//	public GameObject myAsteroid_3;
	private GameObject _asteroid;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("GenerateAsteroid", 1, 1);
	}

	private void GenerateAsteroid(){
		float randNum = Random.value;
		float randNum1 = Random.value;
		float startX;
		if (randNum > 0.5f) {
			startX = transform.position.x + 200*randNum;
		} else {
			startX = transform.position.x - 200*randNum;
		}
		if(randNum1>0.5f){
			_asteroid = Instantiate (myAsteroid_1, new Vector3(startX,160,transform.position.z+100), transform.rotation) as GameObject;
		}else{
			_asteroid = Instantiate (myAsteroid_2, new Vector3(startX,160,transform.position.z+100), transform.rotation) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
