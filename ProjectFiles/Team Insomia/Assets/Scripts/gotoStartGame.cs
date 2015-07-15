using UnityEngine;
using System.Collections;

public class gotoStartGame : MonoBehaviour 
{
	
	public bool isGameStarted = false;
	public bool isSelectionStarted=false;
	
	Animator myAnime;
	
	void Start () 
	{
		myAnime = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelectionStarted == true) 
		{
			myAnime.SetBool("gameStart",true);
		}
	}
	
	
}
