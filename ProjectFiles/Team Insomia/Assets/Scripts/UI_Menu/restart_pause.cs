using UnityEngine;
using System.Collections;

public class restart_pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void restart_pressed () {
		Application.LoadLevel (Application.loadedLevel);
	}
}
