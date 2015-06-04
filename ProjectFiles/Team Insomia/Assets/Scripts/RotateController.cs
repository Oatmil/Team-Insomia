using UnityEngine;
using System.Collections;

public class RotateController : MonoBehaviour {

    public GameObject m_buttonOfCharacter;

	public int speed;
	public int movementSpeed;
	public GameObject myFart;
	//GameObject myNewFart;
	float myTime;
	bool isMove = false;

	Vector3 moveDirection;

	Rigidbody myRigid;

	PressToMove Player1Pressed;

	//fartPos P1fartPos;
    int defaultMoveSpeed;

	void Start () {
		myRigid = GetComponent<Rigidbody> ();
        Player1Pressed = m_buttonOfCharacter.GetComponent<PressToMove>();
		//P1fartPos = GameObject.Find ("fartCubeP1").GetComponent<fartPos> ();
        defaultMoveSpeed = movementSpeed;
	}

	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * speed);
		if(Player1Pressed.P1isPressed == true)
		{
				if(isMove == false)
				{
				//transform.position += transform.forward * Time.deltaTime * movementSpeed;
				myRigid.AddForce(transform.forward * movementSpeed);
				//myNewFart = Instantiate(myFart,P1fartPos.myFartPos,Quaternion.identity)as GameObject;
				speed = 0;
				isMove = true;

				}		
		}


		if(isMove == true)
		{
			myTime += Time.deltaTime;
			if(myTime >= 0.6f)
			{
				isMove = false;
				speed = 100;
				myTime = 0;
				Player1Pressed.P1isPressed = false;
				//Destroy(myNewFart);
                movementSpeed = defaultMoveSpeed;
			}

		}

	
	}


		
}
