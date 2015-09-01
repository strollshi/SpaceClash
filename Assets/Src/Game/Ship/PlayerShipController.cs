using UnityEngine;
using System.Collections;

public class PlayerShipController : MonoBehaviour {

	public GameObject myShip;
	public GameObject Missle;
	public int Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		keyDownDetector ();
		shoot ();
	}

	private void keyDownDetector(){
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(new Vector3(0,0,Speed));
		}else if(Input.GetKey (KeyCode.S)){
			transform.Translate(new Vector3(0,0,-Speed));
		}else if(Input.GetKey (KeyCode.A)){
			transform.Translate(new Vector3(-Speed,0,0));
		}else if(Input.GetKey (KeyCode.D)){
			transform.Translate(new Vector3(Speed,0,0));
		}else if(Input.GetKey (KeyCode.K)){
			myShip.transform.Rotate(new Vector3(0,0,Speed));
		}else if(Input.GetKey (KeyCode.L)){
			myShip.transform.Rotate(new Vector3(0,0,-Speed));
		}

		if (Input.GetKeyUp (KeyCode.K)) {
			GoTweenConfig config = new GoTweenConfig();
			config.setIterations(1);
			config.localRotation(new Vector3(0,0,360));
			config.easeType = GoEaseType.ExpoOut;
			Go.to(myShip.transform,0.5f,config);
		} else if (Input.GetKeyUp (KeyCode.L)) {
			GoTweenConfig config = new GoTweenConfig();
			config.setIterations(1);
			config.localRotation(new Vector3(0,0,-360));
			config.easeType = GoEaseType.ExpoOut;
			Go.to(myShip.transform,0.5f,config);
		}
	}

	private GameObject rightMissle;
	private GameObject leftMissle;
	private bool isInvoked = false;

	public void shoot(){
		if (Input.GetKey (KeyCode.J)) {
			if(!isInvoked){
				isInvoked = true;
				InvokeRepeating("CreateMissle",0,0.1f);
			}
		}
		if (Input.GetKeyUp (KeyCode.J)) {
			isInvoked = false;
			CancelInvoke("CreateMissle");
		}
	}
	void CreateMissle(){
		rightMissle = Instantiate(Missle,new Vector3(transform.position.x+5,transform.position.y,transform.position.z+5),myShip.transform.rotation) as GameObject;
		leftMissle = Instantiate(Missle,new Vector3(transform.position.x-5,transform.position.y,transform.position.z+5),myShip.transform.rotation) as GameObject;
	}


	private void beShooted(){
		GameObject.Find ("GameUI").SendMessage("DamageShip");
	}

	private GameObject expls;
	public GameObject Explosion;
	public void DestroyPlayerShip(){
		expls = Instantiate(Explosion,this.gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
		Destroy (this.gameObject);
		Invoke("gotoStatisticPanel",3);
	}

	void gotoStatisticPanel(){
		GlobalManager.GotoStatisticPanel ();
	}
}
