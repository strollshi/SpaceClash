using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpAndScoreController : MonoBehaviour {

	public GameObject HpBar;
	public GameObject ScoreTxt;
	public GameObject MyShip;

	// Use this for initialization
	void Start () {
	
	}


	private int _score=0;
	public void UpdateScore(){
		_score++;
		ScoreTxt.GetComponent<Text> ().text = "Score: " + _score.ToString ();
	}

	private static int damage = 15;
	private static int medicine = 10;
	private const int STARTX = 300;
	private void UpdateHpBar(bool isAdd){
		GoTweenConfig config;
		config = new GoTweenConfig();
		config.setIterations(1);
		config.easeType = GoEaseType.ExpoOut;

		float endX;

		if (isAdd) {
			if(HpBar.transform.localPosition.x<0){
				endX = HpBar.transform.localPosition.x+medicine;
				if(endX>0){
					endX = 0;
				}
			}else{
				endX = 0;
			}
		} else {
			if(HpBar.transform.localPosition.x>-STARTX){
				endX = HpBar.transform.localPosition.x-damage;
				if(endX<-STARTX){
					endX = -STARTX;
				}
			}else{
				endX = -STARTX;
			}
		}

		config.localPosition(new Vector3(endX,HpBar.transform.localPosition.y,HpBar.transform.localPosition.z));
		Go.to(HpBar.transform,0.3f,config);

		//player dead
		if (endX == -STARTX) {
			MyShip.SendMessage("DestroyPlayerShip");
		}
	}

	public void DamageShip(){
		UpdateHpBar(false);
	}
	public void CureShip(){
		UpdateHpBar(true);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.I)) {
//
//		}
//		if (Input.GetKeyDown (KeyCode.O)) {
//
//		}
//		if (Input.GetKeyDown (KeyCode.P)) {
//			UpdateScore();
//		}
	}
}
