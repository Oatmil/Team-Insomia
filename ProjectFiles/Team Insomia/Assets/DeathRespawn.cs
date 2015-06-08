using UnityEngine;
using System.Collections;

public class DeathRespawn : MonoBehaviour {
    Vector3 DefaultStartingPoint;
	// Use this for initialization
	void Start () {
        DefaultStartingPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -15f)
        {
            transform.position = DefaultStartingPoint;
        }
	}
}
