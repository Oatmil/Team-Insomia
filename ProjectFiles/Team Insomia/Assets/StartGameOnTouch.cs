using UnityEngine;
using System.Collections;

public class StartGameOnTouch : MonoBehaviour 
{

	gotoStartGame gameFlag;
	SpriteRenderer spr_r;
	[HideInInspector]public int JesterCounter=0;
	ClassicGameScript classicGame;
	[HideInInspector]public string[] JesterNames= new string[4];
	// Use this for initialization
	void Start () 
	{
		gameFlag = GameObject.Find ("Main Camera").GetComponent<gotoStartGame> ();
		spr_r = gameObject.GetComponent<SpriteRenderer>();
		classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(JesterCounter>1&&gameFlag.isSelectionStarted)
			spr_r.enabled=true;

		if(classicGame.currentPhase==GamePhases.RoundConfirmation)
		{
			spr_r.enabled=true;
		}
	
	}
	void OnTouchStay()
	{
	  if(spr_r.enabled)
		{
			if(classicGame.currentPhase==GamePhases.RoundConfirmation)
			{
				classicGame.currentPhase = GamePhases.RoundAnnouncement;
					spr_r.enabled=false;
			}
			else
			{
				gameFlag.isGameStarted=true;
				gameFlag.isSelectionStarted=false;
				spr_r.enabled=false;
				classicGame.enabled=true;
				classicGame.ScriptStart(JesterNames, JesterCounter);
			}
		}
	}
}
