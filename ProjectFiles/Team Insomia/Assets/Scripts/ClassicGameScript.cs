using UnityEngine;
using System.Collections;
enum GamePhases{Round, RoundAnnouncement, MatchEnding} 
public class ClassicGameScript : MonoBehaviour 
{
	public int RoundDuration=30;
	public int numberOfRounds=3;
	public int AnnouncementTime=3;
	int currentRound=0;
	float timer=0;
	GamePhases currentPhase=GamePhases.RoundAnnouncement;
	GameObject jes1,jes2,jes3,jes4;

	//For resetting purpose at the start of each round
	GameObject[] MovingObjects = new GameObject[5];
	GameObject[] Buttons = new GameObject[4];
	Vector3[] MovingObjectsP = new Vector3[5];
	Spotlight spotlightScript;
	int winnerPlayer=0;
	void Start () 
	{
		currentRound=1;
		//Prepare an array of all moving obejcts
		for(int i=0;i<5;i++)
		{
			if(i<4)
			{
				MovingObjects[i]=GameObject.Find("Jester"+((i+1).ToString()));
			}
			else
			{
				MovingObjects[i]=GameObject.Find("/Score_Spotlight");
			}
		}
	
		//Prepare an array of the starting positions of said objects
		for(int i=0;i<5;i++)
		{
			MovingObjectsP[i]=MovingObjects[i].transform.position;
		}

		spotlightScript=GameObject.Find("Score_Spotlight").gameObject.GetComponent<Spotlight>();

		for(int i=0;i<4;i++)
		{
			Buttons[i]=GameObject.Find("/button P"+(i+1).ToString());

		}

	}

	void AnnounceRound()
	{
		currentPhase = GamePhases.RoundAnnouncement;
		timer +=Time.deltaTime;
		for(int i=0; i<4;i++)
		{
			Buttons[i].GetComponent<PressToMove>().P1isPressed=false;
		}
		if(timer>AnnouncementTime)
		{
			timer=0;
			currentPhase=GamePhases.Round;
		}


	}
	void UpdateRound()
	{
		timer +=Time.deltaTime;
		//round ended
		if(timer >RoundDuration)
		{
			timer=0;
			currentRound++;
			if(currentRound <=numberOfRounds)
			currentPhase = GamePhases.RoundAnnouncement;
			else
			currentPhase=GamePhases.MatchEnding;
			for(int i=0; i<4;i++)
			{
				Buttons[i].GetComponent<PressToMove>().P1isPressed=false;
			}
			for(int i=0;i<5;i++)
			{
				if(MovingObjects[i])
				{
					MovingObjects[i].transform.position = MovingObjectsP[i];
					if(MovingObjects[i].GetComponent<Rigidbody>())
					MovingObjects[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
				}
			}

			spotlightScript.parentPlayer=null;
			spotlightScript.gameObject.transform.parent =null;
	

		}
	}
	void EndMatch()
	{
		winnerPlayer=1;
		for(int i=0;i<4;i++)
		{
			if(MovingObjects[i].GetComponent<Scoring>().score > MovingObjects[winnerPlayer-1].GetComponent<Scoring>().score)
			{
				winnerPlayer = i+1;
			}
		}
		for(int i=0; i<4;i++)
		{
			Buttons[i].GetComponent<PressToMove>().P1isPressed=false;
		}
		for(int i=0;i<5;i++)
		{
			if(MovingObjects[i])
			{
				MovingObjects[i].transform.position = MovingObjectsP[i];
				if(MovingObjects[i].GetComponent<Rigidbody>())
					MovingObjects[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(currentPhase==GamePhases.RoundAnnouncement)
		AnnounceRound();
		else if(currentPhase==GamePhases.Round)
		UpdateRound();
		else if(currentPhase==GamePhases.MatchEnding)
		EndMatch();

	}

	void OnGUI()
	{
		if(currentPhase == GamePhases.RoundAnnouncement)
		{
            Debug.Log("round 1");
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,400,400), "Round "+(currentRound.ToString()));
		}
		else if(currentPhase == GamePhases.MatchEnding)
		{
			GUI.Label(new Rect(400,400,400,400), "Winner is: Player "+(winnerPlayer.ToString()));
		}
	}
}
