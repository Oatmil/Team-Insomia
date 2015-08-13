using UnityEngine;
using System.Collections;

public class particelsystem : MonoBehaviour {

	ParticleSystem particlesystem = null;
	// Use this for initialization
	void Start () {
		particlesystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (particlesystem.IsAlive () == false) {
			Destroy(gameObject);
		}
	}
}
