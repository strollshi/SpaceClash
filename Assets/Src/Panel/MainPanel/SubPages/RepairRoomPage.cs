using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RepairRoomPage : MonoBehaviour {

	public GameObject Ship;

	private GameObject _ship;

	void Awake() {
		_ship = Instantiate (Ship, new Vector3 (1500, 0, -120), transform.rotation) as GameObject;
		_ship.transform.SetParent (GameObject.Find("MainPanel").transform);
		GameObject content = GameObject.Find ("Content");
		for (int i =1; i<9; i++) {
			string objName = "ColorBox" + i.ToString ();
			GameObject obj = GameObject.Find (objName) as GameObject;
			obj.GetComponent<Button>().onClick.AddListener(delegate {
				onClickColorPicker(objName);
			});
		}
	}

	private void onClickColorPicker(string name){
		Color cl = GameObject.Find (name).GetComponent<Image>().color;
		_ship.GetComponent<MeshRenderer> ().material.color = cl;
		GlobalManager.shipColor = cl;
	}

	// Use this for initialization
	void Start () {

	}

	private void RotateShip(){
			_ship.transform.Rotate (Vector3.down*0.5f);
	}

	public void ShowList(){
		_ship.transform.localPosition = new Vector3 (1500, 0, -120);
		_ship.SetActive(true);
		InvokeRepeating ("RotateShip", 0f, 0.002f);

		GoTweenConfig config = new GoTweenConfig ();
		config.setIterations (1);
		config.easeType = GoEaseType.ExpoOut;
		config.localPosition (new Vector3 (-390, -30, 0));
		config.delay = 0.5f;
		Go.to (transform, 0.5f, config);

		config = new GoTweenConfig ();
		config.scale (new Vector3 (200, 200, 200));
		config.localPosition (new Vector3 (50, 0, -120));
		config.easeType = GoEaseType.ExpoOut;
		Go.to (_ship.transform, 1f, config);

	}

	public void HideList() {
		CancelInvoke ("RotateShip");

		_ship.SetActive(false);

		GoTweenConfig config = new GoTweenConfig ();
		config.setIterations (1);
		config.easeType = GoEaseType.ExpoOut;
		config.localPosition (new Vector3 (-590, -30, 0));
		config.delay = 0.5f;
		Go.to (transform, 0.5f, config);
	}
	
	// Update is called once per frame
	float _deltaY;
	float _deltaX;
	void Update () {

	}
}
