using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoundSelectionPage : MonoBehaviour {

	private List<GameObject> items = new List<GameObject>();

	public GameObject RoundText;

	void Awake() {
		int lv = PlayerPrefs.GetInt ("Level");

		GameObject content = GameObject.Find ("Content");
		for (int i =0; i<8; i++) {
			string objName = "Round"+(i+1).ToString();
			GameObject obj = GameObject.Find(objName) as GameObject;
			obj.AddComponent<Text>();
			obj.AddComponent<Button>();
			int index = items.Count;
			GameObject txtObj = Instantiate(RoundText,new Vector3(0,0,0),obj.transform.rotation) as GameObject;
			txtObj.transform.SetParent(obj.transform);
			Text txt = txtObj.GetComponent<Text>();
			txt.transform.localPosition = new Vector3(0,50,0);
			txtObj.transform.localScale = new Vector3(1,1,1);
			if(lv>=i){
				txt.text = "ROUND"+(i+1).ToString();
				obj.GetComponent<Button>().onClick.AddListener(delegate {
					OnClickRoundSelectionBtn(index);
				});
			}else{
				txt.text = "LOCK";
//				obj.GetComponent<Image>().color.a = 20;
			}


			items.Add(obj);
		}

	}

	private void OnClickRoundSelectionBtn(int index){
		GlobalManager.level = index;
		GlobalManager.GotoLoadingPanel ();
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
