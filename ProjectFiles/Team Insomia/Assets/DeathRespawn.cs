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
            Vector3 position = DefaultStartingPoint;
			position.x = Random.Range(-3,3);
			position.z = Random.Range(-3,3);
			transform.position =position;

        }
	}
}
