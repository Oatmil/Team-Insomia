using UnityEngine;
using System.Collections;

public class HandleAnimation : MonoBehaviour 
{
	Animator anim;
	PressToMove buttonScript;
	Rigidbody rb; 
	RotateController rc;
	// Use this for initialization
	void Start () 
	{
		anim = this.transform.FindChild("Jester_Animated").GetComponent<Animator>();	
		buttonScript = this.gameObject.GetComponent<RotateController>().m_buttonOfCharacter.GetComponent<PressToMove>();
		rc = this.gameObject.GetComponent<RotateController>();
		rb=this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("isCharging", buttonScript.P1startCharging);
		if(rc)
		anim.SetBool("isMoving",rc.isMove);

		//Debug.Log(rc.isMove);
	}
}
