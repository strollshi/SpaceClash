using UnityEngine;
using System.Collections;

public class PlayerShipController : MonoBehaviour {

	public GameObject myShip;
	public GameObject Missle;
	public int Speed;

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = new Vector3 (-400, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		keyDownDetector ();
		shoot ();
//		positionRestrain ();
	}

	private float _deltaX = -400;
	private float _deltaY = 0;
	private void positionRestrain(){
		_deltaX = this.gameObject.transform.position.x - _deltaX;
		if (this.gameObject.transform.position.x + _deltaX > -100) {
			this.gameObject.transform.position = new Vector3(-100,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		}else if(this.gameObject.transform.position.x + _deltaX < -700){
			this.gameObject.transform.position = new Vector3(-700,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		}
		_deltaY = this.gameObject.transform.position.y - _deltaY;
		if(this.gameObject.transform.position.y + _deltaY > 0){
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,0,this.gameObject.transform.position.z);
		}else if(this.gameObject.transform.position.y + _deltaY < -150){
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,-150,this.gameObject.transform.position.z);
		}
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
		this.gameObject.SetActive (false);
		GoTweenConfig config = new GoTweenConfig ();
		config.onComplete (delegate {
			Destroy (this.gameObject);
			GlobalManager.isPassed = false;
			GlobalManager.GotoStatisticPanel ();
			PlayerPrefs.SetInt("Score",GlobalManager.score);
			PlayerPrefs.SetInt("Level",GlobalManager.level);
		});
		Go.to (this.gameObject.transform, 2, config);
	}
}
