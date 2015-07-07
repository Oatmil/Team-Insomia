using UnityEngine;
using System.Collections;

public class gotoStartGame : MonoBehaviour {

	public bool isGameStarted = false;

	Animator myAnime;

	void Start () {
		myAnime = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	if (isGameStarted == true) {
			myAnime.SetBool("gameStart",true);
		}
	}


}
