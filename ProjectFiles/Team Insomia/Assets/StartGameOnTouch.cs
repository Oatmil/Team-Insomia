using UnityEngine;
using System.Collections;

public class StartGameOnTouch : MonoBehaviour 
{

	gotoStartGame gameFlag;
	SpriteRenderer spr_r;
	[HideInInspector]public int JesterCounter=0;
	ClassicGameScript classicGame;
	[HideInInspector]public string[] JesterNames= new string[4];
    [HideInInspector]
    public PressToMove[] PTM = new PressToMove[4];
    public bool[] JesterActive = new bool[4];

	// Use this for initialization
	void Start () 
	{
		gameFlag = GameObject.Find ("Main Camera").GetComponent<gotoStartGame> ();
		spr_r = gameObject.GetComponent<SpriteRenderer>();
		classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();
        for (int i = 0; i < 4; i++)
        {
            PTM[i] = GameObject.Find("button P" + (i + 1).ToString()).GetComponent<PressToMove>();
        }
	}

    // Update is called once per frame
    void Update() 
	{
        //if(JesterCounter>1&&gameFlag.isSelectionStarted)
        //    spr_r.enabled=true;

        //if(classicGame.currentPhase==classicGame.RoundConfirmation)
        //{
        //    spr_r.enabled=true;
        //}

        
	
	}
    void OnTouchDown()
	{
	  if(spr_r.enabled)
		{
			if(classicGame.currentPhase==classicGame.RoundConfirmation)
			{
				classicGame.currentPhase = classicGame.RoundAnnouncement;
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
