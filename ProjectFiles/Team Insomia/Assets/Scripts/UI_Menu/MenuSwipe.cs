using UnityEngine;
using System.Collections;

public class MenuSwipe : MonoBehaviour
{

	Vector2 startingPos;
	Vector2 endingPos;
	public GameObject Mode01;
	public GameObject Mode02;
	public GameObject Mode03;
	MainMenuCheck isAnimationDone;

	void Start ()
	{
		isAnimationDone = GetComponent<MainMenuCheck> ();
	}

	void Update ()
	{
		if(isAnimationDone.isAnimationDone == true)
		{

			Vector3 Cube1Pos = transform.FindChild ("GameMode01").localPosition;
			Vector3 Cube2Pos = transform.FindChild ("GameMode02").localPosition;
			Vector3 Cube3Pos = transform.FindChild ("GameMode03").localPosition;

			if (Input.touchCount == 1) {
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					startingPos.x = Input.GetTouch (0).position.x;
				} else if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					endingPos.x = Input.GetTouch (0).position.x;

				} else if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					if (endingPos.x >= startingPos.x+50) {
					
						Cube1Pos.x +=2.5f;
						Cube2Pos.x +=2.5f;
						Cube3Pos.x +=2.5f;
									
					} else if (endingPos.x <= startingPos.x-50) {
					
						Cube1Pos.x -=2.5f;
						Cube2Pos.x -=2.5f;
						Cube3Pos.x -=2.5f;
					
					}
				}
			}

			transform.FindChild ("GameMode01").localPosition = Cube1Pos;
			transform.FindChild ("GameMode02").localPosition = Cube2Pos;
			transform.FindChild ("GameMode03").localPosition = Cube3Pos;

		}



	}
}
