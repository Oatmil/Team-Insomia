using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour 
{
	public GameObject parentPlayer=null;
	public Scoring scoringScript;
	float timer=0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(parentPlayer!=null)
		{
			gameObject.transform.parent = parentPlayer.transform;

			scoringScript=parentPlayer.GetComponent<Scoring>();
			addScore();
		}
	

	}

	void addScore()
	{
		timer+=Time.deltaTime;
		if(timer>1)
		{
			timer=0;
			scoringScript.score++;
		}

	}


}
