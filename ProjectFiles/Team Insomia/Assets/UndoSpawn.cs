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

    }

    void OnTouchDown()
    {
        //StartScript.JesterNames["the correct index"] = null;      
        for (int i = 0; i < StartScript.JesterNames.Length; i++)
        {
            string Name = StartScript.JesterNames[i];
            
            if (Name == presstospawn.JesterToThis.name)
            {
                Debug.Log(Name);
                for (int j=0; j<StartScript.JesterNames.Length - i; j++)
                    StartScript.JesterNames[i] = StartScript.JesterNames[j];
            }
            Debug.Log(StartScript.JesterNames[i]);
        }
        presstospawn.JesterToThis.SetActive(false);
        presstospawn.spawnedJester = false;

        StartScript.JesterCounter--;
        presstospawn.isReady = false;
        gameObject.SetActive(false);
    }
}
