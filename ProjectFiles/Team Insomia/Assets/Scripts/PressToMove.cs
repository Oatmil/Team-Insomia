using UnityEngine;
using System.Collections.Generic;

public class PressToMove : MonoBehaviour
{

    public GameObject m_JesterToThisButton;
    public GameObject m_pressToRespawnCanvas;
    float fartCharge;

    [HideInInspector]
    public int ChargeRate;
    [HideInInspector]
    public float MaxMove;
    public bool P1isPressed;
    [HideInInspector]
    public bool P1startCharging = false;
    RotateController P1SpeedCharging;
    GameSettings settings;
    public Color defaultColour;
    public Color selectedColour;
    private Material mat;
    DeathRespawn respawn;
    public float respawnCounter;
    ClassicGameScript classicGame;

    [HideInInspector] public bool resetButton = false;

    float defaultrotation;
    void Start()
    {
        P1isPressed = false;
        P1SpeedCharging = m_JesterToThisButton.GetComponent<RotateController>();
        mat = GetComponent<Renderer>().material;
        settings = GameObject.Find("MatchManager").GetComponent<GameSettings>();
        ChargeRate = settings.JesterChargeRate;
        MaxMove = settings.JesterMaxMove;
        respawn = m_JesterToThisButton.GetComponent<DeathRespawn>();
        classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();
    }

    void Update()
    {
        //Debug.Log(fartCharge + " " + P1SpeedCharging.movementSpeed + " " + MaxMove);
        if (P1startCharging)
        {
            if (P1SpeedCharging.movementSpeed < MaxMove)
            {
                P1SpeedCharging.delayedDuration = P1SpeedCharging.movementSpeed / MaxMove;
                P1SpeedCharging.movementSpeed += ChargeRate;
            }
            else
            {
                P1SpeedCharging.movementSpeed = MaxMove;
                OnTouchUp();
            }
        }
        if (respawn.death == true)
        {
            m_pressToRespawnCanvas.SetActive(true);
        }
        else
        {
            m_pressToRespawnCanvas.SetActive(false);
        }
        respawnCounter -= Time.deltaTime;
        if (respawnCounter <= 0)
            respawn.death = false;
        // Debug.Log(P1SpeedCharging.movementSpeed);

    }
    void OnTouchStay()
    {
        if (respawn.death == false)
        {
            mat.color = selectedColour;

            if (P1isPressed == false)
            {
                P1startCharging = true;
            }
        }

    }

    void OnTouchDown()
    {
        resetButton = true;
        if (respawn.death == true)
        {
            // Debug.Log("respawncounter" + respawnCounter);
            respawnCounter -= 1.0f;
        }
    }
    void OnTouchUp()
    {
        if (classicGame.currentPhase == classicGame.Round)
        {
            mat.color = defaultColour;

            if (P1isPressed == false)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                P1startCharging = false;
                P1isPressed = true;
            }
        }
    }
}
