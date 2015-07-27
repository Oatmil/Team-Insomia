using UnityEngine;
using System.Collections;

public class pause_ : MonoBehaviour {

	public GameObject myPauseMenu;
	public bool pauseMenu_isOn = false;
	GameObject playerButton;

	void Start () {
		playerButton = GameObject.Find ("Button");
	}
	

	void Update () {
	
	}
	public void PausePressed()
	{
		if (pauseMenu_isOn == false) {

			myPauseMenu.SetActive (true);
			pauseMenu_isOn = true;
			Time.timeScale = 0;

			playerButton.SetActive(false);

		} else {
			myPauseMenu.SetActive (false);
			pauseMenu_isOn = false;
			Time.timeScale = 1;

			playerButton.SetActive(true);
		}

	}
}
