using UnityEngine;
using System.Collections;

public class AnimationLogo : MonoBehaviour {

	public float rotateSpeed = 10.0f;
	public float rotateSpeed2 = 2.0f;
	public GameObject GameMode02;
	void Update () {

		transform.Rotate(Vector3.forward *(-rotateSpeed*Time.deltaTime));


		if (GetComponentInParent<MainMenuCheck> ().isPressed == true) {

			rotateSpeed = 0;
			gameObject.transform.eulerAngles += new Vector3(-rotateSpeed2,0.0f,0.0f);
			if(gameObject.transform.eulerAngles.x <= 270)
			{
				Destroy(this.gameObject);
				GameMode02.SetActive(true);

			}

		}
	}

    void OnMouseDown()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play ();
    }
}
