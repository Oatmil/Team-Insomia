using UnityEngine;
using System.Collections;

public class MainMenuCheck : MonoBehaviour
{
	
	public bool isPressed;
	public bool isAnimationDone = false;
	float myTime;
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			isPressed = true;
		}
		if (isAnimationDone == false) {
			if (isPressed == true) {
				
			}
		}
		
		
		
	}
}
