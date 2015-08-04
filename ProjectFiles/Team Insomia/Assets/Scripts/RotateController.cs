using UnityEngine;
using System.Collections;

public class RotateController : MonoBehaviour {

    public GameObject m_buttonOfCharacter;
    public GameObject m_PowerGrow;
    public GameObject m_PowerShrink;
    public GameObject SpawnPickUpPos;

    [HideInInspector] public float m_pickUpMovespeedmodifier;
	public int speed;
	[HideInInspector] public float movementSpeed;
	
	float myTime;
	[HideInInspector]public bool isMove = false;
    bool clockwise = true;
	GameSettings settings;
	Vector3 moveDirection;
    int tempSpeed;

	[HideInInspector]public float delayedDuration;
	Rigidbody myRigid;
    int fartSpawns=0;
	PressToMove Player1Pressed;
    float defaultMoveSpeed;

	void Start () {
		myRigid = GetComponent<Rigidbody> ();
        Player1Pressed = m_buttonOfCharacter.GetComponent<PressToMove>();
        defaultMoveSpeed = movementSpeed;
		settings = GameObject.Find("MatchManager").GetComponent<GameSettings>();
		movementSpeed = settings.JesterMovementSpeed;
        tempSpeed = settings.JesterSpeed;
	}

	void Update () {
		if(Player1Pressed.P1isPressed == true)
		{
			speed = 0;
				if(isMove == false)
				{
				//transform.position += transform.forward * Time.deltaTime * movementSpeed;
                    if (transform.position.y < 5.2f)
                    {
                        if (Player1Pressed.resetButton == true)
                        {
                            myRigid.AddForce(transform.forward * movementSpeed * m_pickUpMovespeedmodifier);
                            fartSpawns = Random.Range(0, 5);
                            Player1Pressed.resetButton = false;
                        }
                    }
                if (fartSpawns == 1)
                {
                    GameObject shrink1 = GameObject.Instantiate(m_PowerShrink, SpawnPickUpPos.transform.position, Quaternion.identity) as GameObject;
                    shrink1.transform.eulerAngles = new Vector3(Random.Range(25, 65), Random.Range(25, 65), Random.Range(25, 65));
                }
                if (fartSpawns == 2)
                {
                    GameObject grow1 = GameObject.Instantiate(m_PowerGrow, SpawnPickUpPos.transform.position, Quaternion.identity) as GameObject;
                    grow1.transform.eulerAngles = new Vector3(Random.Range(25, 65), Random.Range(25, 65), Random.Range(25, 65));
                }
				//myNewFart = Instantiate(myFart,P1fartPos.myFartPos,Quaternion.identity)as GameObject;

				//if(myRigid.velocity.magnitude == 0f)
					isMove = true;
				}		
		}


		if(isMove == true)
		{
            //Debug.Log(myTime);
            myTime += Time.deltaTime;
            if (myTime >= delayedDuration + 0.2f)
            {
                isMove = false;
                myTime = 0;
                if (clockwise == false)
                {
                    speed = -tempSpeed;
                    clockwise = true;
                    //Debug.Log("ANTI CLOCKWISE" + speed);
                }
                else if (clockwise == true)
                {
                    speed = tempSpeed;
                    clockwise = false;
                   // Debug.Log("CLOCKWISE" + speed);

                }
                Player1Pressed.P1isPressed = false;
                //Destroy(myNewFart);
                movementSpeed = defaultMoveSpeed;
            }

		}
//        Debug.Log(Time.deltaTime);
		//Debug.Log (speed);
		transform.eulerAngles += new Vector3(0.0f,speed*Time.deltaTime,0.0f);
	}


		
}
