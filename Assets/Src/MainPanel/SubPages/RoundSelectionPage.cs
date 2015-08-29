using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoundSelectionPage : MonoBehaviour {

	private List<GameObject> items = new List<GameObject>();

	void Awake() {
		GameObject content = GameObject.Find ("Content");
		for (int i =1; i<9; i++) {
			string objName = "Round"+i.ToString();
			GameObject obj = GameObject.Find(objName) as GameObject;
			obj.AddComponent<Button>();
			int index = items.Count;
			obj.GetComponent<Button>().onClick.AddListener(delegate {
				OnClickRoundSelectionBtn();
			});
			items.Add(obj);
		}

	}

	private void OnClickRoundSelectionBtn(){
		GlobalManager.LoadSceneName = "GameScene";
		Application.LoadLevel ("LoadingScene");
	}

	// Use this for initialization
	void Start () {

	}

	public void ShowList() {
//		GoTweenConfig config;
//		for (int i=0; i<items.Count; i++) {
//			config = new GoTweenConfig();
//			GameObject item = items[i] as GameObject;
//			config.delay = i*0.1f + 0.5f;
//			config.localPosition(new Vector3(item.transform.localPosition.x,0,item.transform.localPosition.y));
//			config.easeType = GoEaseType.ExpoOut;
////			Color cl = Color.white;
////			cl.a = 50;
////			config.colorProp ("color", cl);
//			Go.to (item.transform,0.5f,config);
//		}
	}

	public void HideList() {
//		GoTweenConfig config;
//		for (int i=0; i<items.Count; i++) {
//			config = new GoTweenConfig();
//			GameObject item = items[i] as GameObject;
//			config.delay = i*0.1f;
//			config.localPosition(new Vector3(item.transform.localPosition.x,-100,item.transform.localPosition.y));
//			config.easeType = GoEaseType.ExpoOut;
////			Color cl = Color.white;
////			cl.a = 0;
////			config.colorProp ("color", cl);
//			Go.to (item.transform,0.5f,config);
//		}
	}

	public void Dispose() {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
