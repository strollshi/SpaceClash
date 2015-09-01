using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	private float force;
	private float rotationX;
	private float rotationY;
	private float rotationZ;
	private float size;

	public GameObject Explosion;

	// Use this for initialization
	void Start () {
//		Debug.Log ("asteroid created");
		size = Random.Range (0.3f, 1f) * 30;
		force = -Random.Range(0.5f,1f) * 100;
		rotationX = Random.Range(0.2f,1f) * 10;
		rotationY = Random.Range(0.2f,0.5f) * 5;
		rotationZ = Random.Range(0.2f,0.5f) * 5;

		this.transform.localScale = new Vector3 (size, size, size);

//		this.gameObject.transform.localPosition = new Vector3 (0, 0, 0);
		Invoke ("DestroyAsteroid", 8);
	}

	void DestroyAsteroid(){
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (this.gameObject.transform.position);
		this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,force,0));
		this.gameObject.transform.Rotate(new Vector3(rotationX,rotationY,rotationZ));
	}


	private GameObject expls;
	void OnTriggerEnter(Collider cols){
		if (cols.gameObject.tag == "Missle" || cols.gameObject.tag == "Player") {
			expls = Instantiate(Explosion,this.gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
			expls.transform.localScale = this.gameObject.transform.localScale * 2;
			Destroy(this.gameObject);
			Debug.Log("asteroid hitted");
		}
	}
}
