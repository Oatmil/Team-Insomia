using UnityEngine;
using System.Collections;

public class OffsetCheck : MonoBehaviour {

 		
	MainMenuCheck isAnimationDone;

	Vector3 myPos;
	Vector3 myScale;
	void Start () {

		isAnimationDone = GameObject.Find ("MainMenu").GetComponent<MainMenuCheck> ();
	}
	

	void Update () {
		if (isAnimationDone.isAnimationDone == true) {
			myPos = transform.localPosition;
			myScale = transform.localScale;
			if (myPos.x >= 3.5f) {
				myPos.x = -2;
			}
			else if(myPos.x <= -2.5f)
			{
				myPos.x = 3;
			}
			if(myPos.x > -1.5f && myPos.x <2.5f)
			{
				myScale.x = 2.5f;
				myScale.y = 3.2f;
				GetComponent<BoxCollider>().enabled = true;
			}
			else
			{
				myScale.x = 1.8f;
				myScale.y = 2.5f;
				GetComponent<BoxCollider>().enabled = false;
				
			}
			transform.localScale = myScale;
			transform.localPosition = myPos;


		}

	}
}
