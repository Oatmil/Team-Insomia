using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressToSpawn : MonoBehaviour 
{
	gotoStartGame gameFlag;
	public GameObject JesterToThis;
	PressToMove moveScript;
	StartGameOnReadyOrTouch StartScript;
	RotateController RC;
	[HideInInspector] public bool isReady;
	//Text ReadyText;

	bool spawnedJester=false;
	//public GameObject TextElementToThis;
	public GameObject ReadyOn;
	public GameObject ReadyOff;
	Image ReadyImageOn;
	Image ReadyImageOff;
	public GameObject ButtonImage;
	bool loadedSprites=false;
	// Use this for initialization
	void Start () 
	{
		gameFlag=GameObject.Find ("Main Camera").GetComponent<gotoStartGame> ();
		moveScript=gameObject.GetComponent<PressToMove>();
		moveScript.enabled=false;
		StartScript = GameObject.Find("ui_btn_start").GetComponent<StartGameOnReadyOrTouch>();
		RC = JesterToThis.GetComponent<RotateController> ();
		ReadyOn.SetActive(true);
		ReadyOff.SetActive(true);



		//		ReadyText =TextElementToThis.GetComponent<Text>();
//		ReadyText.text = "Not Ready";
//		ReadyText.color = new Color(255,0,0);

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameFlag.isSelectionStarted) 
		{
			RC.speed=0;
			moveScript.enabled=false;
			if(!loadedSprites)
			{
				loadedSprites=true;
				ReadyImageOn = ReadyOn.GetComponent<Image>();
				ReadyImageOff = ReadyOff.GetComponent<Image>();
			}
			if(isReady)
			{
//				ReadyText.text = "Ready";
//				ReadyText.color = new Color(0,0,255);
				ReadyImageOn.enabled=true;
				ReadyImageOff.enabled=false;
				ButtonImage.SetActive(false);
			}
			else
			{
//				ReadyText.text = "Not Ready";
//				ReadyText.color = new Color(255,0,0);
				ReadyImageOn.enabled=false;
				ReadyImageOff.enabled=true;
				ButtonImage.SetActive(false);
			}
		}
		if(gameFlag.isGameStarted)
		{
			RC.speed=200;
			moveScript.enabled=true;
			if(StartScript.round1Started)
			{
				ReadyImageOn.enabled=false;
				ReadyImageOff.enabled=false;
				ButtonImage.SetActive(true);
			}
		//	ReadyText.color= new Color(0,0,0);
		}
	}
	void OnTouchDown()
	{
		if(!StartScript.round1Started)
		{

			if(!spawnedJester)
			{
				if(!JesterToThis.activeSelf)
				{
					JesterToThis.SetActive(true);
					StartScript.JesterCounter++;
					StartScript.JesterNames[StartScript.JesterCounter-1]=JesterToThis.name;
					spawnedJester=true;
				}
			}
			//Setting Ready or Not Ready after spawning Jester
			else
			{
				if(!isReady)
					isReady=true;
				else isReady=false;
				if(StartScript.isActiveAndEnabled)
				StartScript.CheckReady();
			}



		}


	}
    void OnTouchUp()
    {

    }
}
