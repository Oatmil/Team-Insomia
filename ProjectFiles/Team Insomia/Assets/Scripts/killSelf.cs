using UnityEngine;
using System.Collections;

public class killSelf : MonoBehaviour {

	public float killTimer;
	bool killBool = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (killBool == true) {
			killTimer -= Time.deltaTime;
			if(killTimer <= 0.0f)
			{
				Destroy (this.gameObject);
			}
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Stage") {
			killBool = true;
		}
	}

}
