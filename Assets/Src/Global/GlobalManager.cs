using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class GlobalManager : MonoBehaviour {

	public static int[] lvScore = {10,20,30,40,50,60,70,80,90};

	public static string LoadSceneName;

	public static int score = 0;
	public static bool isPassed = false;
	public static int exp;
	public static int level;
	public static Color shipColor;
	public static int hp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void GotoStatisticPanel(){
		Application.LoadLevel ("StatisticScene");
	}

	public static void GotoLoadingPanel(){
		Application.LoadLevel ("LoadingScene");
	}

	public static void GotoGamePanel(){
		Application.LoadLevel ("GameScene");
	}
}
