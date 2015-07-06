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
				myScale.x = 0.425f;
				myScale.y = 0.5f;
				GetComponent<BoxCollider>().enabled = true;
			}
			else
			{
				myScale.x = 0.34f;
				myScale.y = 0.4f;
				GetComponent<BoxCollider>().enabled = false;
				
			}
			transform.localScale = myScale;
			transform.localPosition = myPos;


		}

	}
}
