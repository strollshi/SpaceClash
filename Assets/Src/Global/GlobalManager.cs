using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class GlobalManager : MonoBehaviour {

	public static string LoadSceneName;

	public static int score = 0;
	public static bool isPassed = false;
	public static int exp;
	public static int level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void CreateInfo(){
		Application.persistentDataPath
	}
}
