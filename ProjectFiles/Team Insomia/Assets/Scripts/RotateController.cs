using UnityEngine;
using System.Collections;

public class RotateController : MonoBehaviour {

	int speed;
	public int movementSpeed;
	public GameObject myFart;
	GameObject myNewFart;
	float myTime;
	bool isMove = false;

	Vector3 moveDirection;

	Rigidbody myRigid;

	PressToMove Player1Pressed;
	PressToMove Player2Pressed;

	fartPos P1fartPos;
	fartPos P2fartPos;
	

	void Start () {
		speed = 100;
		movementSpeed = 500;
		myRigid = GetComponent<Rigidbody> ();
		Player1Pressed = GameObject.Find ("buttonP1").GetComponent<PressToMove> ();
		Player2Pressed = GameObject.Find ("buttonP2").GetComponent<PressToMove> ();
		P1fartPos = GameObject.Find ("fartCubeP1").GetComponent<fartPos> ();
		P2fartPos = GameObject.Find ("fartCubeP2").GetComponent<fartPos> ();
		
	}

	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * speed);
		if(Player1Pressed.P1isPressed == true)
		{
			if(gameObject.name == "Jester1")
			{
				if(isMove == false)
				{
				//transform.position += transform.forward * Time.deltaTime * movementSpeed;
				myRigid.AddForce(transform.forward * movementSpeed);
				myNewFart = Instantiate(myFart,P1fartPos.myFartPos,Quaternion.identity)as GameObject;
				speed = 0;
				isMove = true;

				}
			}
		
		}

		if(Player2Pressed.P2isPressed == true)
		{
			if(gameObject.name == "Jester2")
			{
				if(isMove == false)
				{
					//transform.position += transform.forward * Time.deltaTime * movementSpeed;
				myRigid.AddForce(transform.forward * movementSpeed);
				myNewFart = Instantiate(myFart,P2fartPos.myFartPos,Quaternion.identity)as GameObject;
				
				speed = 0;
				isMove = true;
					
				}
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
				Player2Pressed.P2isPressed = false;
				Destroy(myNewFart);
				movementSpeed = 500;
			}

		}

	
	}


		
}
