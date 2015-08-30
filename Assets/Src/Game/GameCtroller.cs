using UnityEngine;
using System.Collections;

public class GameCtroller : MonoBehaviour {

	private static GameCtroller Instance;
	public static GameCtroller getInstane{
		get{
			if(!Instance){
				Instance = new GameCtroller();
			}
			return Instance;
		}
	}


	private HpAndScoreController hpAndScoreCtrl;

	// Use this for initialization
	void Start () {
		hpAndScoreCtrl = new HpAndScoreController ();
//		Invoke ("gotoStatisticPanel", 5);
	}

	public void CurePlayerShip(){
		hpAndScoreCtrl.UpdateHpBar (true);
	}

	public void DamagePlayerShip(){
		hpAndScoreCtrl.UpdateHpBar (false);
	}

	public void UpdateScore(){
		hpAndScoreCtrl.UpdateScore ();
	}

	public void DamageEnemyShip(){

	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void gotoStatisticPanel(){
		Application.LoadLevel ("StatisticScene");
	}
}
