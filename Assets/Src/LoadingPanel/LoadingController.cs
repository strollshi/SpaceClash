using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour {

	public GameObject ProgressBar;
	public GameObject PercentageTxt;

	// Use this for initialization
	void Start () {
		ProgressBar.transform.localPosition = new Vector3 (-500,0,0);
		GoTweenConfig config = new GoTweenConfig ();
		config.localPosition(new Vector3 (0, 0, 0));
		config.delay = 1f;
		config.setIterations (1);
		config.onUpdate (delegate(AbstractGoTween obj)
		{
			onProgress();
		});
		config.onComplete (delegate {
			Application.LoadLevel(GlobalManager.LoadSceneName);
		});
		Go.to (ProgressBar.transform, 4, config);
	}

	void onProgress(){
		float percentage = Mathf.Ceil(100 * ProgressBar.transform.position.x / 500);
		PercentageTxt.GetComponent<Text> ().text = percentage.ToString () + "%";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
