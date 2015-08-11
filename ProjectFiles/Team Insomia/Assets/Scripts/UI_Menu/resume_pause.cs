using UnityEngine;
using System.Collections;

public class resume_pause : MonoBehaviour {

	public GameObject pauseMenu_Parent;
	public GameObject playerButton;

	pause_ myPausebtnL;
	pause_ myPausebtnR;

	void Start () {
		myPausebtnL = GameObject.Find ("pauseBTN_L").GetComponent < pause_> ();
		myPausebtnR = GameObject.Find ("pauseBTN_R").GetComponent < pause_> ();
		
	}
	
	// Update is called once per frame
	void Update () {


	
	}
	public void resume_pressed()
	{

		pauseMenu_Parent.SetActive (false);
		Time.timeScale = 1;
		playerButton.SetActive(true);

		if (myPausebtnL.pauseMenu_isOn == true || myPausebtnR.pauseMenu_isOn == true) {
			myPausebtnL.pauseMenu_isOn = false;
			myPausebtnR.pauseMenu_isOn = false;
			
		}


	}
}
