﻿using UnityEngine;
using System.Collections.Generic;

public class PressToMove : MonoBehaviour
{

    public GameObject m_JesterToThisButton;
    public GameObject m_pressToRespawnCanvas;
    public GameObject m_ReadyCanvas;

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
    AudioSource audio3;
    public AudioClip endSOund;
    public GameObject EndPS;
    [HideInInspector] public bool resetButton = false;

    float defaultrotation;
    void Start()
    {
        audio3 = GetComponent<AudioSource>();
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
        if (respawn.death == true && classicGame.currentPhase == classicGame.Round)
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

        if (classicGame.currentPhase == classicGame.MatchEnding)
        {
            
            audio3.clip = endSOund;
        }
        // Debug.Log(P1SpeedCharging.movementSpeed);

    }
    void OnTouchStay()
    {
		if(respawn)
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
        if (classicGame.currentPhase == classicGame.MatchEnding)
        {
            audio3.Play();
            GameObject EndParticleSystem = Instantiate(EndPS, transform.position, Quaternion.Euler(EndPS.transform.position)) as GameObject;
        }
        resetButton = true;
		if(respawn)
        if (respawn.death == true)
        {
            // Debug.Log("respawncounter" + respawnCounter);
            respawnCounter -= 1.0f;
        }
    }
    void OnTouchUp()
	{
		if(classicGame)
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
