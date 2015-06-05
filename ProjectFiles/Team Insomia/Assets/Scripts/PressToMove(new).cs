using UnityEngine;
using System.Collections;

public class PressToMove : MonoBehaviour {

	public bool P1isPressed;
	public bool P2isPressed;
	bool P1startCharging = false;
	bool P2startCharging = false;
	RotateController P1SpeedCharging;
	RotateController P2SpeedCharging;

	public GameObject myFart;
	GameObject myNewFart;
		
	fartPos P1fartPos;
	fartPos P2fartPos;

	void Start () {
		P1isPressed = false;
		P2isPressed = false;
		P1SpeedCharging = GameObject.Find ("Player").GetComponent<RotateController> ();
		P2SpeedCharging = GameObject.Find ("Player2").GetComponent<RotateController> ();
		P1fartPos = GameObject.Find ("fartCubeP1").GetComponent<fartPos> ();
		P2fartPos = GameObject.Find ("fartCubeP2").GetComponent<fartPos> ();
	
		
	}
	

	void Update () {
		Debug.Log (P1SpeedCharging.movementSpeed);
		if (P1startCharging) {
				
			P1SpeedCharging.myRigid.AddForce(P1SpeedCharging.transform.forward * P1SpeedCharging.movementSpeed);
							
			
			
		}
		if (P2startCharging) {

			P2SpeedCharging.myRigid.AddForce(P2SpeedCharging.transform.forward * P2SpeedCharging.movementSpeed);
				
		}

	}
	void OnMouseDown()
	{
		if (P1isPressed == false) {
			if(gameObject.name == "buttonP1")
			{
				
				P1startCharging = true;
				P1SpeedCharging.isMove = true;
			}
		}
		if (P2isPressed == false) {
			if(gameObject.name == "buttonP2")
			{
				P2startCharging = true;
				P2SpeedCharging.isMove = true;
				
			}
		}
	}

	void OnMouseUp()
	{
		P1SpeedCharging.isMove = false;
		P2SpeedCharging.isMove = false;
		P1startCharging = false;
		P2startCharging = false;

		

	}
}
