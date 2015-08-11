using UnityEngine;
using System.Collections;

public class credit_Menu : MonoBehaviour {

	public GameObject mainMenu_Parent;
	Vector3 creditAnim;
	bool isCreditBTN_pressed = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown () {

		isCreditBTN_pressed = true;
	}
	void Update()
	{
		if(isCreditBTN_pressed == true)
		{
			creditAnim = mainMenu_Parent.transform.position;
			
			creditAnim.x -= 0.1f;		
			
			mainMenu_Parent.transform.position = creditAnim;
		}

	}
}
