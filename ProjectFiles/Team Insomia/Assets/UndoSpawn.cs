using UnityEngine;
using System.Collections;

public class UndoSpawn : MonoBehaviour
{

    PressToSpawn presstospawn;
    ClassicGameScript classicGame;
    StartGameOnReadyOrTouch StartScript;


    public GameObject m_Button;
    // Use this for initialization
    void Start()
    {
        presstospawn = m_Button.GetComponent<PressToSpawn>();
        classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();
        StartScript = GameObject.Find("ui_btn_start").GetComponent<StartGameOnReadyOrTouch>();

    }

    // Update is called once per frame
    void Update()
    {
        if (classicGame.currentPhase == classicGame.Round)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTouchDown()
    {
        //StartScript.JesterNames["the correct index"] = null;
        presstospawn.JesterToThis.SetActive(false);

        for (int i = 0; i < StartScript.JesterNames.Length; i++)
        {
            string Name = StartScript.JesterNames[i];

            if (Name == presstospawn.JesterToThis.name)
            {
  //              Debug.Log(Name);

                for (int j = 0; j <StartScript.JesterNames.Length -i -1 ; j++)
                {  
  //                  Debug.Log(j);
                        StartScript.JesterNames[i + j] = StartScript.JesterNames[i + j +1];

                }
                StartScript.JesterNames[3] = "";
                //StartScript.JesterNames[3] = "";
 //       Debug.Log("array 0:                   " + StartScript.JesterNames[0] + ":");
 //       Debug.Log("array 1:                   " + StartScript.JesterNames[1] + ":");
 //       Debug.Log("array 2:                   " + StartScript.JesterNames[2] + ":");
  //      Debug.Log("array 3:                   " + StartScript.JesterNames[3] + ":");
       
            }
        }
         StartScript.JesterCounter -= 1;
        presstospawn.spawnedJester = false;
        gameObject.SetActive(false);
        presstospawn.isReady = false;
    }
}
