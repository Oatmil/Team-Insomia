using UnityEngine;
using System.Collections;

public class DeathRespawn : MonoBehaviour {
    Vector3 DefaultStartingPoint;
    public bool death = false;
    bool changeState = false;
    public GameObject button;
    PressToMove MoveScript;
	// Use this for initialization
	void Start () {
        MoveScript = (PressToMove)button.GetComponent(typeof(PressToMove));
        DefaultStartingPoint = transform.position;
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
                changeState = false;
                Vector3 position = DefaultStartingPoint;
                position.x = Random.Range(-3, 3);
                position.z = Random.Range(-3, 3);
                transform.position = position;
                this.GetComponent<Rigidbody>().useGravity = true;

            }
        }
        
	}
}
