using UnityEngine;
using System.Collections;

public class RotateController : MonoBehaviour {

	int speed;
	public int movementSpeed;
	//public GameObject myFart;
	//GameObject myNewFart;
	float myTime;
	public bool isMove = false;

	Vector3 moveDirection;

	public Rigidbody myRigid;

	PressToMove Player1Pressed;
	PressToMove Player2Pressed;

//	fartPos P1fartPos;
//	fartPos P2fartPos;
	

	void Start () {
		speed = 100;
		movementSpeed = 20;
		myRigid = GetComponent<Rigidbody> ();
		Player1Pressed = GameObject.Find ("buttonP1").GetComponent<PressToMove> ();
		Player2Pressed = GameObject.Find ("buttonP2").GetComponent<PressToMove> ();
//		P1fartPos = GameObject.Find ("fartCubeP1").GetComponent<fartPos> ();
//		P2fartPos = GameObject.Find ("fartCubeP2").GetComponent<fartPos> ();
		
	}

	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * speed);
		if(Player1Pressed.P1isPressed == true)
		{
			if(gameObject.name == "Player")
			{
				if(isMove == false)
				{
				//transform.position += transform.forward * Time.deltaTime * movementSpeed;
				//myRigid.AddForce(transform.forward * movementSpeed);
				//myNewFart = Instantiate(myFart,P1fartPos.myFartPos,Quaternion.identity)as GameObject;
				
				//isMove = true;

				}
			}
		
		}

		if(Player2Pressed.P2isPressed == true)
		{
			if(gameObject.name == "Player2")
			{
				if(isMove == false)
				{
				//transform.position += transform.forward * Time.deltaTime * movementSpeed;
				//myRigid.AddForce(transform.forward * movementSpeed);
				//myNewFart = Instantiate(myFart,P2fartPos.myFartPos,Quaternion.identity)as GameObject;
				
				//isMove = true;
					
				}
			}
			
		}

		if (isMove == true) {
			speed = 0;
		

		} else {
			myTime += Time.deltaTime;
			if(myTime >= 0.6f)
			{
			
				speed = 100;
				myTime = 0;
				Player1Pressed.P1isPressed = false;
				Player2Pressed.P2isPressed = false;
				//Destroy(myNewFart);
				movementSpeed = 20;
			}
		}

	
	}


		
}
