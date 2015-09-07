using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatisticPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("MovePanel", 1);

		GameObject.Find ("ReplayBtn").GetComponent<Button> ().onClick.AddListener (delegate {
			GlobalManager.GotoGamePanel();
		});
		GameObject.Find ("ReturnBtn").GetComponent<Button> ().onClick.AddListener (delegate {
			GlobalManager.GotoUIPanel();
		});
	}

	private void setStatisticData(){
		if (GlobalManager.isPassed) {
			GameObject.Find ("TitleTxt").GetComponent<Text> ().text = "Win";
		} else {
			GameObject.Find("TitleTxt").GetComponent<Text>().text = "Lose";
		}
		GameObject.Find ("ScoreTxt").GetComponent<Text> ().text = "Score : " + GlobalManager.score.ToString ();
		GameObject.Find ("LevelTxt").GetComponent<Text> ().text = "Level : " + (GlobalManager.level+1).ToString ();
	}

	private void MovePanel(){
		GoTweenConfig config = new GoTweenConfig ();
		config.easeType = GoEaseType.BackOut;
		config.setIterations (1);
		config.localPosition (Vector3.zero,false);
		Go.to (GameObject.Find ("ScorePanel").transform, 0.5f, config);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
