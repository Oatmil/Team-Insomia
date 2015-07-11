using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour 
{
	public GameObject parentPlayer=null;
	public Scoring scoringScript;
	float timer=0;
    float heightposition;
	// Use this for initialization
	void Start () 
	{
        heightposition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(parentPlayer!=null)
		{
			gameObject.transform.parent = parentPlayer.transform;
        	transform.localPosition = new Vector3 (0.0f,heightposition,0.0f);
			
			scoringScript=parentPlayer.GetComponent<Scoring>();
			addScore();
		}
        transform.position = new Vector3 (transform.position.x,heightposition,transform.position.z);
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
