using UnityEngine;
using System.Collections;

public class PressToSpawn : MonoBehaviour 
{
	gotoStartGame gameFlag;
	public GameObject JesterToThis;
	PressToMove moveScript;
	StartGameOnTouch StartScript;
	// Use this for initialization
	void Start () 
	{
		gameFlag=GameObject.Find ("Main Camera").GetComponent<gotoStartGame> ();
		moveScript=gameObject.GetComponent<PressToMove>();
		moveScript.enabled=false;
		StartScript = GameObject.Find("ui_btn_start").GetComponent<StartGameOnTouch>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameFlag.isGameStarted)
		{
			moveScript.enabled=true;
		}
	}
	void OnTouchStay()
	{
		if(gameFlag.isSelectionStarted&!gameFlag.isGameStarted)
		{
			if(!JesterToThis.activeSelf)
			{
				JesterToThis.SetActive(true);
				StartScript.JesterCounter++;
				StartScript.JesterNames[StartScript.JesterCounter-1]=JesterToThis.name;
			}
		}
	}
}
