using UnityEngine;
using System.Collections;

public class fartPos : MonoBehaviour {

	public Vector3 myFartPos;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		myFartPos = transform.position;
	}
}
