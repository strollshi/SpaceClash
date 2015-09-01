using UnityEngine;
using System.Collections;

public class MissleController : MonoBehaviour {

	public int Speed;
	public int Direction = 1;//1 or -1

	void Awake(){
//		Debug.Log ("missle created");
		Invoke ("DestroyMissle", 1);
	}

	// Use this for initialization
	void Start () {
		this.gameObject.transform.localScale = new Vector3 (15, 15, 15);
	}

	void DestroyMissle(){
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (this.gameObject.transform.position.y.ToString());
		this.gameObject.transform.Translate(new Vector3(0,0,Direction*Speed));
	}
}
