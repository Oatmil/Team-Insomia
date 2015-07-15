using UnityEngine;
using System.Collections;

public class AnimationBTN : MonoBehaviour {

	public float rotateSpeed = 10.0f;
	public float rotateSpeed2 = 2.0f;

	bool isDoneAnimFor_GM_Btn = false;

	public GameObject GameMode02;

	MainMenuCheck boolCheck;
	AnimationGameMode animationEndCheck;

	CircleCollider2D myCircleCollider;

	void Start()
	{
		boolCheck = GameObject.Find ("MainMenu").GetComponent<MainMenuCheck> ();
		animationEndCheck = GameMode02.GetComponent<AnimationGameMode> ();
		myCircleCollider = GameMode02.GetComponent<CircleCollider2D> ();
	}

	void Update () {

		if (animationEndCheck.isEndAnimation_Logo == true) {

			if(gameObject.name == "Credit")
			{
				Vector3 myYPos = transform.localPosition;
				if(myYPos.y > 6.05f)
				{
					myYPos.y -= 0.1f;

				}
				else
				{
					myYPos.y = 6.05f;
					
				}

				transform.localPosition = myYPos;
			}
			if(gameObject.name == "Tutorial")
			{
				Vector3 myYPos = transform.localPosition;
				if(myYPos.y < 6.05f)
				{
					myYPos.y += 0.1f;
					
				}
				else
				{
					myYPos.y = 6.05f;
					
				}
				transform.localPosition = myYPos;
				
			}
			if(isDoneAnimFor_GM_Btn == false)
			{
				if(gameObject.name == "GameMode01")
				{
					Vector3 myYPos = transform.localPosition;
					if(myYPos.x < -7.5f)
					{
						myYPos.x += 0.1f;

					}
					else
					{
						myYPos.x = -7.5f;
						isDoneAnimFor_GM_Btn = true;
						
					}
					transform.localPosition = myYPos;
					
				}
				if(gameObject.name == "GameMode03")
				{
					Vector3 myYPos = transform.localPosition;
					if(myYPos.x > 8.5f)
					{
						myYPos.x -= 0.1f;
						
					}
					else
					{
						myYPos.x = 8.5f;
						isDoneAnimFor_GM_Btn = true;
						boolCheck.isAnimationDone = true;
						
					}

					transform.localPosition = myYPos;


				}
			}

			//Debug.Log (isDoneAnimFor_GM_Btn);
		}


		if (boolCheck.isAnimationDone == true) {
			if(gameObject.name == "GameMode03" || gameObject.name == "GameMode01")
			{
				transform.Rotate(Vector3.forward *(rotateSpeed*Time.deltaTime));
				
			}
			else
			{
				transform.Rotate(Vector3.forward *(-rotateSpeed*Time.deltaTime));
			}

			myCircleCollider.enabled = true;
				
		}
		
	}
}
