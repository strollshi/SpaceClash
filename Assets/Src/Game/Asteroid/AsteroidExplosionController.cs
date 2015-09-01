using UnityEngine;
using System.Collections;

public class AsteroidExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyExplosion", 2);
	}

	void DestroyExplosion(){
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
