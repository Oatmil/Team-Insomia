﻿using UnityEngine;
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

			Vector3 Cube1Pos = Mode01.transform.localPosition;
			Vector3 Cube2Pos = Mode02.transform.localPosition;
			Vector3 Cube3Pos = Mode03.transform.localPosition;

			if (Input.touchCount == 1) {
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					startingPos.x = Input.GetTouch (0).position.x;
				} else if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					endingPos.x = Input.GetTouch (0).position.x;

				} else if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					if (endingPos.x >= startingPos.x+50) {
					
						Cube1Pos.x += 8f;
						Cube2Pos.x += 8f;
						Cube3Pos.x += 8f;
									
					} else if (endingPos.x <= startingPos.x-50) {
					
						Cube1Pos.x -= 8f;
						Cube2Pos.x -= 8f;
						Cube3Pos.x -= 8f;
					
					}
				}
			}

			Mode01.transform.localPosition = Cube1Pos;
			Mode02.transform.localPosition = Cube2Pos;
			Mode03.transform.localPosition = Cube3Pos;

		}



	}
}
