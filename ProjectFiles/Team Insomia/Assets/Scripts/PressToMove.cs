using UnityEngine;
using System.Collections.Generic;

public class PressToMove : MonoBehaviour {

    public GameObject m_JesterToThisButton;

	[HideInInspector] public int ChargeRate;
	[HideInInspector] public int MaxMove;
	public bool P1isPressed;
	bool P1startCharging = false;
	RotateController P1SpeedCharging;
	GameSettings settings;
    public Color defaultColour;
    public Color selectedColour;
    private Material mat;

	void Start () {
		P1isPressed = false;
        P1SpeedCharging = m_JesterToThisButton.GetComponent<RotateController>();
        mat = GetComponent<Renderer>().material;
		settings = GameObject.Find("MatchManager").GetComponent<GameSettings>();
		ChargeRate=settings.JesterChargeRate;
		MaxMove =settings.JesterMaxMove;

	}

	void Update () {
		if (P1startCharging) {
            if (P1SpeedCharging.movementSpeed < MaxMove)
			{
                P1SpeedCharging.movementSpeed += ChargeRate;
			}
			else
			{
                //OnTouchUp();
			}
		}
       
		Debug.Log (P1SpeedCharging.movementSpeed);
	}
	void OnTouchDown()
	{
        mat.color = selectedColour;

		if (P1isPressed == false) {
				P1startCharging = true;
		}
	}

	void OnTouchUp()
	{
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        mat.color = defaultColour;

		if (P1isPressed == false) {
				P1startCharging = false;
				P1isPressed = true;
		}
	}

}
