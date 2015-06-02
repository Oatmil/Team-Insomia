using UnityEngine;
using System.Collections;

public class PressToMove : MonoBehaviour {

	public bool P1isPressed;
	public bool P2isPressed;
	bool P1startCharging = false;
	bool P2startCharging = false;
	RotateController P1SpeedCharging;
	RotateController P2SpeedCharging;
	

	void Start () {
		P1isPressed = false;
		P2isPressed = false;
		P1SpeedCharging = GameObject.Find ("Jester1").GetComponent<RotateController> ();
		P2SpeedCharging = GameObject.Find ("Jester2").GetComponent<RotateController> ();
		
	}
	

	void Update () {
		if (P1startCharging) {
			if( P1SpeedCharging.movementSpeed<1000)
			{
				P1SpeedCharging.movementSpeed += 5;
			}
			else
			{
				//OnMouseUp();
				
			}
		}
		if (P2startCharging) {

			if( P2SpeedCharging.movementSpeed<1000)
			{
				P2SpeedCharging.movementSpeed += 5;
			}
			else
			{
				OnMouseUp();
				
			}
			
		}
		Debug.Log (P1SpeedCharging.movementSpeed);
	}
	void OnMouseDown()
	{
		if (P1isPressed == false) {
			if(gameObject.name == "buttonP1")
			{
				
				P1startCharging = true;
			}
		}
		if (P2isPressed == false) {
			if(gameObject.name == "buttonP2")
			{
				P2startCharging = true;
			}
		}
	}

	void OnMouseUp()
	{

		if (P1isPressed == false) {
			if(gameObject.name == "buttonP1")
			{
				P1startCharging = false;
				P1isPressed = true;
			}
		}
		if (P2isPressed == false) {
			if(gameObject.name == "buttonP2")
			{
				P2isPressed = true;
				P2startCharging = false;
			}
		}
	}
}
