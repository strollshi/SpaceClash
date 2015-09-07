using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainPanel : Panel {


	private string status = "mainPanel";

	/**
	 * 
	 * vars save the gameobjects that the main panel contains
	 * */
	private List<GameObject> btnsTrans = new List<GameObject>(); 
	private GameObject bg;
	public GameObject Ship;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		Init ();

		//show bg after 1s
		Invoke ("Show", 1);
	}


	private GoTweenConfig bgColorConfig = new GoTweenConfig ();
	private GoTweenConfig shipConfig = new GoTweenConfig ();
	private void Init(){
		Ship.transform.localScale =  Vector3.zero;

		//init bg
		bg = GameObject.Find ("Bg");
		bg.GetComponent<Image> ().color = Color.black;

		//init btns transforms
		btnsTrans.Add(GameObject.Find("PlayBtn"));
		btnsTrans.Add(GameObject.Find("HelpBtn"));
		btnsTrans.Add(GameObject.Find("RankBtn"));

		bgColorConfig.setIterations(1);
		bgColorConfig.colorProp ("color", Color.gray);
		bgColorConfig.easeType = GoEaseType.ExpoOut;

		GameObject.Find ("TopBar").GetComponentInChildren<Button> ().onClick.AddListener (delegate {
			gotoMainPanelPage();
		});
	}

	private void RotateShip(){
		Ship.transform.Rotate (Vector3.down);
	}

	public void onClickBtn(string btnName){
		if (btnName == "PlayBtn") {
			gotoRoundSelectionPage();
		} else if (btnName == "HelpBtn") {
			gotoReqiarRoomPage();
		} else if (btnName == "RankBtn") {
			gotoSettingPage();
		}
	}



	/****
	 * sub page
	 * ***/

	public GameObject RoundPage;
	public GameObject RepairPage;
	public GameObject SettingPage;

	private GameObject _roundPage;
	private GameObject _repairPage;

	void gotoRoundSelectionPage() {
		Hide ();
		status = "roundSelection";

		if (!_roundPage) {
			_roundPage = Instantiate (RoundPage, new Vector3(0,0,0), transform.rotation) as GameObject;
		}
		_roundPage.transform.SetParent (transform);
		_roundPage.transform.localPosition = new Vector3 (15, 0, 0);
		_roundPage.transform.localScale = new Vector3(1,1,0);
		_roundPage.GetComponent<RoundSelectionPage> ().ShowList ();
	}

	void gotoReqiarRoomPage() {
		Hide ();
		status = "reqairRoom";

		if (!_repairPage) {
			_repairPage = Instantiate (RepairPage, new Vector3 (0, 0, 0), transform.rotation) as GameObject;
		}
		_repairPage.transform.SetParent (transform);
		_repairPage.transform.localPosition = new Vector3 (-590, -30, 0);
		_repairPage.transform.localScale = new Vector3 (1, 1, 0);
		_repairPage.GetComponent<RepairRoomPage> ().ShowList ();
	}

	void gotoSettingPage() {
		Hide ();
		status = "rank";

	}

	void gotoMainPanelPage() {
		Hide ();
		status = "mainPanel";
		Show ();
	}


	private bool isFirstShow = false;

	public void Show(){
		base.Show ();

		if (!isFirstShow) {
			isFirstShow = true;
			InvokeRepeating ("RotateShip", 0, 0.02f);
		}

		Image bgImg = bg.GetComponent<Image> ();
		Go.to (bgImg, 2f, bgColorConfig);

		GlobalManager.shipColor = Ship.GetComponent<MeshRenderer>().material.color;

		shipConfig = new GoTweenConfig ();
		shipConfig.setIterations (1);
		shipConfig.easeType = GoEaseType.ExpoInOut;
		shipConfig.localPosition(new Vector3(-50,-30,-130));
		shipConfig.scale (new Vector3 (200, 200, 200));
		Ship.transform.localScale = new Vector3 (0, 0, 0);
		Go.to (Ship.transform, 1, shipConfig);

		for (int i=0; i<btnsTrans.Count; i++) {
			GoTweenConfig config = new GoTweenConfig();
			config.localPosition(new Vector3(350,110*(1-i),0),false);
			config.delay = 0.5f+0.05f*i;
			config.setIterations(1);
			config.easeType = GoEaseType.ExpoOut;
			Go.to (btnsTrans[i].transform, 1f , config);
			string btnName = btnsTrans[i].name;
			btnsTrans[i].GetComponent<Button>().onClick.AddListener(delegate {
				onClickBtn(btnName);
			});
		}
	}

	public void Hide(){
		base.Hide ();

		switch (status) {
			case("mainPanel"):
				HideMainPanelPage();
				break;
			case("roundSelection"):
				HideRoundSelectionPage();
				break;
			case("reqairRoom"):
				HideReqairRoomPage();
				break;
			case("rank"):
				HideSettingPage();
				break;
		}
	}

	private void HideMainPanelPage(){
		bgColorConfig.setIterations(1);
		bgColorConfig.colorProp ("color", Color.black);
		bgColorConfig.easeType = GoEaseType.ExpoOut;
		Image bgImg = bg.GetComponent<Image> ();
		Go.to (bgImg, 1f, bgColorConfig);

		for (int i=0; i<btnsTrans.Count; i++) {
			GoTweenConfig config = new GoTweenConfig ();
			config.localPosition (new Vector3 (800, 110 * (1 - i), 0), false);
			config.delay = 0.05f * i;
			config.setIterations (1);
			config.easeType = GoEaseType.ExpoOut;
			Go.to (btnsTrans [i].transform, 1f, config);
		}

		GoTweenConfig topBarConfig = new GoTweenConfig ();
		topBarConfig.setIterations (1);
		topBarConfig.localPosition (new Vector3 (0,250,0));
		topBarConfig.delay = 0.5f;
		topBarConfig.easeType = GoEaseType.ExpoOut;
		Go.to (GameObject.Find ("TopBar").transform, 0.5f, topBarConfig);

		shipConfig = new GoTweenConfig ();
		shipConfig.localPosition (new Vector3 (-1200, -40, -162));
		shipConfig.easeType = GoEaseType.ExpoOut;
		Go.to (GameObject.Find ("ShipModel").transform, 1f, shipConfig);
	}

	private void HideRoundSelectionPage(){
		HideTopBar ();
		_roundPage.SendMessage("HideList");
		_roundPage.transform.SetParent (null);
	}

	private void HideReqairRoomPage(){
		HideTopBar ();
		Ship.GetComponent<MeshRenderer> ().material.color = GlobalManager.shipColor;
		_repairPage.SendMessage("HideList");
		_repairPage.transform.SetParent (null);
	}

	private void HideSettingPage(){
		HideTopBar ();
	}

	private void HideTopBar(){
		GoTweenConfig topBarConfig = new GoTweenConfig ();
		topBarConfig.setIterations (1);
		topBarConfig.localPosition (new Vector3 (0,375,0));
		topBarConfig.easeType = GoEaseType.ExpoOut;
		Go.to (GameObject.Find ("TopBar").transform, 0.5f, topBarConfig);
	}

	public void Dispose(){
		base.Dispose ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
