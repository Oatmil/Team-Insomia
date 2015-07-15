using UnityEngine;
using System.Collections;

public class RotateController : MonoBehaviour {

    public GameObject m_buttonOfCharacter;

	public int speed;
	[HideInInspector] public float movementSpeed;
	//GameObject myNewFart;
	float myTime;
	[HideInInspector]public bool isMove = false;
    bool clockwise = true;
	GameSettings settings;
	Vector3 moveDirection;

	[HideInInspector]public float delayedDuration;
	Rigidbody myRigid;

	PressToMove Player1Pressed;

	//fartPos P1fartPos;
    float defaultMoveSpeed;

	void Start () {
		myRigid = GetComponent<Rigidbody> ();
        Player1Pressed = m_buttonOfCharacter.GetComponent<PressToMove>();
		//P1fartPos = GameObject.Find ("fartCubeP1").GetComponent<fartPos> ();
        defaultMoveSpeed = movementSpeed;
		settings = GameObject.Find("MatchManager").GetComponent<GameSettings>();
		movementSpeed = settings.JesterMovementSpeed;
	}

	void Update () {
		if(Player1Pressed.P1isPressed == true)
		{
			speed = 0;
				if(isMove == false)
				{
				//transform.position += transform.forward * Time.deltaTime * movementSpeed;
				myRigid.AddForce(transform.forward * movementSpeed);
				//myNewFart = Instantiate(myFart,P1fartPos.myFartPos,Quaternion.identity)as GameObject;

				//if(myRigid.velocity.magnitude == 0f)
					isMove = true;
				}		
		}


		if(isMove == true)
		{
			//Debug.Log(myTime);
			myTime += Time.deltaTime;
			if(myTime >= delayedDuration + 0.2f)
			{
				isMove = false;
				myTime = 0;
                if (clockwise == false)
                {
                    speed = -speed;
                    clockwise = true;

                }
                else if(clockwise == true)
                {
                    speed = -speed;
                    clockwise = false;
                }
				Player1Pressed.P1isPressed = false;
				//Destroy(myNewFart);
                movementSpeed = defaultMoveSpeed;
			}

		}

		//Debug.Log (speed);
		transform.eulerAngles += new Vector3(0.0f,speed*Time.deltaTime,0.0f);
	}


		
}
