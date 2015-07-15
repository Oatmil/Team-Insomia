using UnityEngine;
using System.Collections;

public class AnimationGameMode : MonoBehaviour {

	public float rotateSpeed = 10.0f;
	public float rotateSpeed2 = 2.0f;

	MainMenuCheck boolCheck;
	public bool isEndAnimation_Logo = false;
	
	void Start()
	{
		boolCheck = GameObject.Find ("MainMenu").GetComponent<MainMenuCheck> ();
	}
	void Update () {
		if (transform.eulerAngles.x <= 1f) {
			isEndAnimation_Logo = true;
			
			if(boolCheck.isAnimationDone == true)
			{
				transform.Rotate(Vector3.forward *(rotateSpeed*Time.deltaTime));
			}
			
		} else {
			transform.Rotate (Vector3.left * (rotateSpeed2));
			
		}
	}
}
