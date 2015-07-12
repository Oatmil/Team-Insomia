using UnityEngine;
using System.Collections;

public class HandleAnimation : MonoBehaviour 
{
	Animator anim;
	PressToMove buttonScript;
	Rigidbody rb; 
	RotateController rc;
    ClassicGameScript classicGame;
	// Use this for initialization
	void Start () 
	{
		anim = this.transform.FindChild("Jester_Animated").GetComponent<Animator>();	
		buttonScript = this.gameObject.GetComponent<RotateController>().m_buttonOfCharacter.GetComponent<PressToMove>();
		rc = this.gameObject.GetComponent<RotateController>();
		rb=this.gameObject.GetComponent<Rigidbody>();
        classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (classicGame.currentPhase == classicGame.Round)
        {
            anim.SetBool("isCharging", buttonScript.P1startCharging);
            if (rc)
                anim.SetBool("isMoving", rc.isMove);
        }
		//Debug.Log(rc.isMove);
	}
}
