using UnityEngine;
using System.Collections;

public class tutorial_Menu : MonoBehaviour {

	public GameObject mainMenu_Parent;
	Vector3 tutorialAnim;
	bool isTutorialBTN_pressed = false;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		
		isTutorialBTN_pressed = true;
	}
	void Update()
	{
		if(isTutorialBTN_pressed == true)
		{
			tutorialAnim = mainMenu_Parent.transform.position;
			
			tutorialAnim.x += 0.1f;		
			
			mainMenu_Parent.transform.position = tutorialAnim;
		}
		
	}
}
