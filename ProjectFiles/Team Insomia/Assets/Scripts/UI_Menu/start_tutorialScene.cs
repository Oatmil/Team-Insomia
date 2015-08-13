using UnityEngine;
using System.Collections;

public class start_tutorialScene : MonoBehaviour {

	public Sprite myTutorial01;
	public Sprite myTutorial02;
	public Sprite myTutorial03;
	public Sprite myTutorial04;
	public Sprite myTutorial05;

	Sprite currentSprite;

	SpriteRenderer myRenderer;

	void Start () {
		myRenderer = GameObject.Find ("Tutorial").GetComponent<SpriteRenderer> ();
		currentSprite = myTutorial01;

	}

	void Update () {
		myRenderer.sprite = currentSprite;
	
	}

	void OnMouseDown()
	{
		if (gameObject.name == "tutorial_next") {
			if(currentSprite == myTutorial01)
			{
				currentSprite = myTutorial02;
			}
			else if(currentSprite == myTutorial02)
			{
				currentSprite = myTutorial03;
			}
			else if(currentSprite == myTutorial03)
			{
				currentSprite = myTutorial04;
			}
			else if(currentSprite == myTutorial04)
			{
				currentSprite = myTutorial05;
			}
			else if(currentSprite == myTutorial05)
			{
				currentSprite = myTutorial01;
			}

		}


	}
	
}
