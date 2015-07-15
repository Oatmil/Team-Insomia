using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ClassicGameScript : MonoBehaviour
{
	//GamePhases
	[HideInInspector] public  int Round=0;
	[HideInInspector] public  int RoundAnnouncement=1;
	[HideInInspector] public  int MatchEnding = 2;
	[HideInInspector] public  int RoundConfirmation=3;
	[HideInInspector] public int currentPhase=1;
	
	public bool RoundEnded = true;
	public int RoundDuration;
	public int numberOfRounds;
	public int AnnouncementTime;
	
	int currentRound = 0;
	
	[HideInInspector] public float timer = 0;
	int AliveJesters=0;
	
	
	GUIStyle winnerStyle;
	//For resetting purpose at the start of each round
	GameObject[] MovingObjects = new GameObject[5];
	GameObject[] Buttons = new GameObject[4];
	Vector3[] MovingObjectsP = new Vector3[5];
	Spotlight spotlightScript;
	GameObject winnerPlayer;
	gotoStartGame checkGameStart;
	
	float Restarttime = 10.0f;
	
	public List<Sprite> UISprites = new List<Sprite>();
	int currentUISprite=0;
	Image UIImage;
	
	
	public void ScriptStart(string[] JesterNames, int JesterCount)
	{
		AliveJesters = JesterCount;
		checkGameStart = GameObject.Find ("Main Camera").GetComponent<gotoStartGame> ();
		winnerStyle = new GUIStyle();
		winnerStyle.normal.textColor = Color.black;
		currentRound = 1;
		//Prepare an array of all moving obejcts
		for (int i = 0; i < AliveJesters+1; i++)
		{
			if (i < AliveJesters)
			{
				MovingObjects[i] = GameObject.Find(JesterNames[i]);
			}
			else
			{
				MovingObjects[i] = GameObject.Find("/Score_Spotlight");
			}
		}
		
		//Prepare an array of the starting positions of said objects
		for (int i = 0; i < AliveJesters+1; i++)
		{
			MovingObjectsP[i] = MovingObjects[i].transform.position;
		}
		
		spotlightScript = GameObject.Find("Score_Spotlight").gameObject.GetComponent<Spotlight>();
		
		for (int i = 0; i < 4; i++)
		{
			Buttons[i] = GameObject.Find("/Button/button P" + (i + 1).ToString());
			
		}
		
		UIImage=GameObject.Find("Canvas(RoundUI)").GetComponentInChildren<Image>();
		
		
	}
	int RoundCountdown=3;
	void AnnounceRound()
	{
		spotlightScript.parentPlayer = null;
		spotlightScript.gameObject.transform.parent = null;
		
		UIImage.enabled=true;
		
		if(RoundCountdown==4)
			UIImage.sprite = UISprites[9];
		
		currentPhase = RoundAnnouncement;
		timer += Time.deltaTime;
		for (int i = 0; i < 4; i++)
		{
			
			Buttons[i].GetComponent<PressToMove>().P1isPressed = false;
		}
		for (int i = 0; i < AliveJesters+1; i++)
		{
			if (MovingObjects[i])
			{
				MovingObjects[i].transform.position = MovingObjectsP[i];
				if (MovingObjects[i].GetComponent<Rigidbody>())
					MovingObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
		
		if (timer > 1)
		{
			if(RoundCountdown==4)
			{
				UIImage.sprite = UISprites[currentUISprite];
				currentPhase =RoundConfirmation;
				UIImage.enabled=false;
			}
			else
			{
				currentUISprite++;
				UIImage.sprite = UISprites[currentUISprite];
			}
			
			timer =0;
			RoundCountdown--;
			
		}
		
		if (RoundCountdown<1)
		{
			RoundEnded = false;
			timer = 0;
			RoundCountdown=4;
			currentPhase = Round;
			UIImage.enabled=false;
			
		}
		
		
	}
	void ConfirmRound()
	{
		for (int i = 0; i < 4; i++)
		{
			Buttons[i].GetComponent<PressToMove>().P1isPressed = false;
		}
		for (int i = 0; i < AliveJesters+1; i++)
		{
			if (MovingObjects[i])
			{
				MovingObjects[i].transform.position = MovingObjectsP[i];
				if (MovingObjects[i].GetComponent<Rigidbody>())
					MovingObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
		
	}
	void UpdateRound()
	{
		timer += Time.deltaTime;
		//round ended
		if (timer > RoundDuration)
		{
			timer = 0;
			currentRound++;
			//RoundEnded = true;
			if (currentRound <= numberOfRounds)
				currentPhase = RoundAnnouncement;
			else
				currentPhase = MatchEnding;
			for (int i = 0; i < 4; i++)
			{
				Buttons[i].GetComponent<PressToMove>().P1isPressed = false;
			}
			for (int i = 0; i < AliveJesters+1; i++)
			{
				if (MovingObjects[i])
				{
					MovingObjects[i].transform.position = MovingObjectsP[i];
					if (MovingObjects[i].GetComponent<Rigidbody>())
						MovingObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
				}
			}
			
			spotlightScript.parentPlayer = null;
			spotlightScript.gameObject.transform.parent = null;
			
			
		}
	}
	bool announcedPlayer = false;
	void EndMatch()
	{
		if (!announcedPlayer)
		{
			winnerPlayer = MovingObjects[0];
			for (int i = 1; i < AliveJesters; i++)
			{
				if (MovingObjects[i].GetComponent<Scoring>().score > MovingObjects[i-1].GetComponent<Scoring>().score)
				{
					
					winnerPlayer = MovingObjects[i];
					
				}
			}
			switch (winnerPlayer.name[6])
			{
			case '1':
				
				winnerStyle.normal.textColor = Color.red;
				break;
				
			case '2':
				winnerStyle.normal.textColor = new Color(0, 1f, 0.876f);
				break;
			case '3':
				winnerStyle.normal.textColor = new Color(0.996f, 0.298f, 0.996f);
				break;
			case '4':
				winnerStyle.normal.textColor = new Color(0.627f, 1f, 0.129f);
				break;
			}
			
			for (int i = 0; i < 4; i++)
			{
				Buttons[i].GetComponent<PressToMove>().P1isPressed = false;
			}
			
			
			for (int i = 0; i < AliveJesters+1; i++)
			{
				if (MovingObjects[i])
				{
					MovingObjects[i].transform.position = MovingObjectsP[i];
					if (MovingObjects[i].GetComponent<Rigidbody>())
						MovingObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
				}
			}
		}
		announcedPlayer = true;
	}
	// Update is called once per frame
	void Update()
	{
		if (checkGameStart.isGameStarted == true) {
			if (currentPhase == RoundAnnouncement)
				AnnounceRound ();
			else if (currentPhase == RoundConfirmation)
				ConfirmRound();
			else if (currentPhase == Round)
				UpdateRound ();
			else if (currentPhase == MatchEnding)
			{
				EndMatch ();
				Restarttime -= Time.deltaTime;
			}
		};
		if (Restarttime <= 0)
			Application.LoadLevel (Application.loadedLevel);
	}
	
	void OnGUI()
	{
		//		if (checkGameStart.isGameStarted == true) 
		//		{
		//			GUI.skin.label.fontSize = 60;
		//			if (currentPhase == GamePhases.RoundAnnouncement) {
		//				GUI.Label (new Rect (Screen.width / 3, Screen.height / 3, 400, 400), "Round " + (currentRound.ToString ()));
		//			} else if (currentPhase == GamePhases.Round) {
		//				GUI.Label (new Rect (Screen.width / 9, Screen.height / 3, 150, 400), "Time " + (((int)(RoundDuration - timer + 1)).ToString ()));
		//			} else if (currentPhase == GamePhases.MatchEnding) {
		//				
		//				winnerStyle.fontSize = 60;
		//				GUI.Label (new Rect (Screen.width / 5, Screen.height / 5, 200, 200), "Winner is: Player " + (winnerPlayer.ToString ()), winnerStyle);
		//			}
		//		}
		if (currentPhase == MatchEnding)
		{
			
			winnerStyle.fontSize = 60;
			GUI.Label (new Rect (Screen.width / 5, Screen.height / 5, 200, 200), "Winner is: Player " + winnerPlayer.name[6].ToString(), winnerStyle);
		}
	}
}
