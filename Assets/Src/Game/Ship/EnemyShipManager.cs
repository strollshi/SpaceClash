using UnityEngine;
using System.Collections;

public class EnemyShipManager : MonoBehaviour {

	public GameObject Enemy;
	public GameObject Cam;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateEnemy",1,2);
	}

	private GameObject enemyShip;
	void CreateEnemy(){
		float randNum = Random.value;
		float startX;
		if (randNum > 0.5f) {
			startX = transform.position.x + 200*randNum;
		} else {
			startX = transform.position.x - 200*randNum;
		}
		enemyShip = Instantiate (Enemy, new Vector3 (startX, 200, 0), Enemy.transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
