using UnityEngine;
using System.Collections;

public class DeathRespawn : MonoBehaviour {
    public Vector3 SpawnPoint;
    public bool death = false;
    bool changeState = false;
    public GameObject button;
    PressToMove MoveScript;
    RotateController RotateScript;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        MoveScript = (PressToMove)button.GetComponent(typeof(PressToMove));
        RotateScript = (RotateController)GetComponent(typeof(RotateController));
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -15f)
        {
            if (changeState == false)
            {
                this.GetComponent<Rigidbody>().useGravity = false;
                MoveScript.respawnCounter = 10f;
                death = true;
                changeState = true;
            }
            if(death == false)
            {
                Vector3 position = SpawnPoint;
                Debug.Log("position" + " " + position.x + " " + position.y + " " + position.z);
                position.y = 8.0f;
                transform.position = position;
                transform.LookAt(new Vector3(0, 8, 0));
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(transform.forward * 300);
                changeState = false;
               
            }
        }
        else
            this.GetComponent<Rigidbody>().useGravity = true;
        
	}
}
