using UnityEngine;
using System.Collections.Generic;

public class PressToMove : MonoBehaviour
{

    public GameObject m_JesterToThisButton;
    public GameObject m_fartbar;

    float fartCharge;

    [HideInInspector]
    public int ChargeRate;
    [HideInInspector]
    public float MaxMove;
    public bool P1isPressed;
    bool P1startCharging = false;
    RotateController P1SpeedCharging;
    GameSettings settings;
    public Color defaultColour;
    public Color selectedColour;
    private Material mat;
    DeathRespawn respawn;
    public float respawnCounter;


    void Start()
    {
        P1isPressed = false;
        P1SpeedCharging = m_JesterToThisButton.GetComponent<RotateController>();
        mat = GetComponent<Renderer>().material;
        settings = GameObject.Find("MatchManager").GetComponent<GameSettings>();
        ChargeRate = settings.JesterChargeRate;
        MaxMove = settings.JesterMaxMove;
        respawn = m_JesterToThisButton.GetComponent<DeathRespawn>();
    }

    void Update()
    {
        fartCharge = P1SpeedCharging.movementSpeed / MaxMove;
        Debug.Log(fartCharge + " " + P1SpeedCharging.movementSpeed + " " + MaxMove);
        m_fartbar.transform.localScale = new Vector3(fartCharge, 1.0f, 1.0f);
        if (P1startCharging)
        {
            if (P1SpeedCharging.movementSpeed <= MaxMove)
            {
                P1SpeedCharging.movementSpeed += ChargeRate;
            }
            else
            {
                //OnTouchUp();
            }
        }

        respawnCounter -= Time.deltaTime;
        if (respawnCounter <= 0)
            respawn.death = false;
        // Debug.Log(P1SpeedCharging.movementSpeed);
    }
    void OnTouchStay()
    {
        if (respawn.death == true)
        {
           // Debug.Log("respawncounter" + respawnCounter);
            respawnCounter -= 1.0f;
        }
        else
        {
            mat.color = selectedColour;

            if (P1isPressed == false)
            {
                P1startCharging = true;
            }
        }
    }

    void OnTouchUp()
    {
        if (respawn.death == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
        mat.color = defaultColour;

        if (P1isPressed == false)
        {
            P1startCharging = false;
            P1isPressed = true;
        }
    }
}
