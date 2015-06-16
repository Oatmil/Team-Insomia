using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour 
{
	public GameObject spotlight;
	Spotlight spotlightScript;
	//string name;
	public int score=0;
	GameObject lastTouchedJester=null;
	// Use this for initialization
	void Start () 
	{
		spotlight = GameObject.Find("Score_Spotlight");
		spotlightScript = spotlight.GetComponent<Spotlight>();
		name=gameObject.name;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Spotlight")
		{
			if(spotlightScript.parentPlayer==null)
			{
				Vector3 pos = spotlight.transform.position;
				pos.x = gameObject.transform.position.x;
				pos.z = gameObject.transform.position.z;
				spotlight.transform.position=pos;
			}
		}
	}
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Spotlight")
		{
			if(spotlightScript.parentPlayer==null)
			{
				spotlightScript.parentPlayer = gameObject;
			}
		}

	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Jester")
		{
			lastTouchedJester=other.gameObject;
		}
	}
	void OnCollisionExit(Collision other)
	{
		if(other.gameObject.tag == "Stage")
		{
			if(spotlightScript.parentPlayer ==this.gameObject)
			{
				spotlightScript.parentPlayer=null;
				spotlightScript.gameObject.transform.parent =null;
				if(lastTouchedJester!=null)
				{
					Vector3 pos = spotlight.transform.position;
					pos.x = lastTouchedJester.transform.position.x;
					pos.z = lastTouchedJester.transform.position.z;
					spotlight.transform.position=pos;
				}
				else
				{
					Vector3 pos = spotlight.transform.position;
					pos.x = 0;
					pos.z = 0;
					spotlight.transform.position=pos;
				}
			}
            lastTouchedJester.GetComponent<Scoring>().lastTouchedJester = null;
            lastTouchedJester = null;


		}
	}

	void OnGUI()
	{

        GUI.skin.label.fontSize = 60;
        if (name == "Jester1")
        {
            GUI.Label(new Rect(Screen.width / 10, Screen.height / 10*8, 500, 500), score.ToString());
        }
        if (name == "Jester2")
        {
            GUI.Label(new Rect(Screen.width / 10*8, Screen.height / 10*8, 500, 500), score.ToString());
        }
        if (name == "Jester3")
        {
            GUI.Label(new Rect(Screen.width / 10, Screen.height / 10, 500, 500), score.ToString());
        }
        if (name == "Jester4")
        {
            GUI.Label(new Rect(Screen.width / 10*8, Screen.height / 10, 500, 500), score.ToString());
        }
		
	}

}
