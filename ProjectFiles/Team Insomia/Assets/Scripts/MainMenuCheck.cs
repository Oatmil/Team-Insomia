using UnityEngine;
using System.Collections;

public class MainMenuCheck : MonoBehaviour
{
	
	bool isPressed;
	public bool isAnimationDone = false;
	float myTime;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			isPressed = true;
		}
		if (isAnimationDone == false) {
			if (isPressed == true) {

				Vector3 LogoPos = transform.FindChild ("Logo").position;
				LogoPos.y += 0.12f;
				transform.FindChild ("Logo").position = LogoPos;
				myTime += Time.deltaTime;
				if (myTime > 0.5f) {

					Vector3 Cube1Pos = transform.FindChild ("GameMode01").localPosition;
					Vector3 Cube2Pos = transform.FindChild ("GameMode02").localPosition;
					Vector3 Cube3Pos = transform.FindChild ("GameMode03").localPosition;

					if (Cube1Pos.x > -2) {
						Cube1Pos.x -= 0.3f;

					} else {
						if (Cube2Pos.x > 0.5f) 
						{
							Cube2Pos.x -= 0.2f;

						}
						else if (Cube3Pos.x > 3f) {
							Cube3Pos.x -= 0.2f;
						} else {
							Vector3 Cube2Scale = transform.FindChild ("GameMode02").localScale;
							Cube2Scale.x *= 1.25f;
							Cube2Scale.y *= 1.25f;					
							transform.FindChild ("GameMode02").localScale = Cube2Scale;
							isAnimationDone = true;
						}
					}

					transform.FindChild ("GameMode01").localPosition = Cube1Pos;
					transform.FindChild ("GameMode02").localPosition = Cube2Pos;
					transform.FindChild ("GameMode03").localPosition = Cube3Pos;

				}
			}
		}

		
		
	}
}
