using UnityEngine;
using System.Collections;

public class tutorial_Exit : MonoBehaviour {

	Animator tutorialAnim;

	void Start () {
		tutorialAnim = GameObject.Find ("MainMenu").GetComponent<Animator>();
	}
	
	void OnMouseDown()
	{
		tutorialAnim.SetBool ("startTutorialPlay", false);
	}
}
