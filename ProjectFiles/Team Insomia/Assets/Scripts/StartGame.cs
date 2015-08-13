using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	public GameObject m_camera;
	public GameObject m_Canvas;
	public GameObject m_buttons;

	public GameObject MainMenu;

	public float delayCanvas;
	bool delayTImer = false;
	gotoStartGame checking;
	void Start () {
		checking = m_camera.GetComponent<gotoStartGame> ();
		
	}
	
	void Update()
	{
		if (delayTImer == true)
			delayCanvas -= Time.deltaTime;
		if (delayCanvas <= 0.0f) {
			m_Canvas.SetActive(true);
			m_buttons.SetActive(true);
			delayTImer = false;
			//DestroyImmediate(MainMenu);
		}
	}
	void OnMouseDown()
	{
		checking.isSelectionStarted = true;
		delayTImer = true;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
	}
	
	
}
