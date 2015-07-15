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
			if (myPos.x > 8.5f) {
				myPos.x = -7.5f;
			}
			else if(myPos.x < -7.5f)
			{
				myPos.x = 8.5f;
			}
			if(myPos.x > -1.5f && myPos.x <2.5f)
			{
				myScale.x = 1f;
				myScale.y = 1f;
				GetComponent<CircleCollider2D>().enabled = true;
			}
			else
			{
				myScale.x = 0.7f;
				myScale.y = 0.7f;
				GetComponent<CircleCollider2D>().enabled = false;
				
			}
			transform.localScale = myScale;
			transform.localPosition = myPos;


		}

	}
}
