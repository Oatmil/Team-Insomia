using UnityEngine;
using System.Collections;

public class StartGameOnReadyOrTouch : MonoBehaviour
{

    gotoStartGame gameFlag;
    //SpriteRenderer spr_r;
    [HideInInspector]
    public int JesterCounter = 0;
    ClassicGameScript classicGame;
    bool allReady = false;
    [HideInInspector]
    public bool round1Started = false;
    [HideInInspector]
    public string[] JesterNames = new string[4];

    // Use this for initialization
    void Start()
    {
        gameFlag = GameObject.Find("Main Camera").GetComponent<gotoStartGame>();
       // spr_r = gameObject.GetComponent<SpriteRenderer>();
        classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (JesterCounter > 1 && gameFlag.isSelectionStarted & !gameFlag.isGameStarted)
        {
            if (allReady)
            {
                gameFlag.isGameStarted = true;
                gameFlag.isSelectionStarted = false;
               // spr_r.enabled = false;
               // classicGame.enabled = true;
                classicGame.ScriptStart(JesterNames, JesterCounter);
            }
        }
        //Game started but not all is ready
        if (!round1Started && gameFlag.isGameStarted)
        {
            CheckReady();

            if (!allReady)
            {
                gameFlag.isSelectionStarted = true;
                gameFlag.isGameStarted = false;
                //classicGame.enabled = false;
                classicGame.RoundCountdown = 3;
                classicGame.UIImage.enabled = false;
                classicGame.currentPhase = classicGame.RoundAnnouncement;
                classicGame.currentUISprite = (classicGame.currentRound -1)*3;
                classicGame.UIImage.sprite = classicGame.UISprites[classicGame.currentUISprite];

            }

        }

        if (classicGame.currentPhase == classicGame.RoundConfirmation)
        {
            round1Started = false;
            CheckReady();
          //  spr_r.enabled = true;
            

            if (allReady)
            {
                classicGame.currentPhase = classicGame.RoundAnnouncement;
                //spr_r.enabled = false;
                
                //  gameFlag.isGameStarted = true;
                // gameFlag.isSelectionStarted = false;
                //  spr_r.enabled = false;
                //classicGame.enabled = true;
                // classicGame.ScriptStart(JesterNames, JesterCounter);
            }
            else
            {
                //spr_r.enabled = true;
                
                classicGame.currentPhase = classicGame.RoundConfirmation;
            }
        }

        if (classicGame.currentPhase == classicGame.Round)
        {
            round1Started = true;
        }




    }

    //    void OnTouchStay()
    //    {
    //        if(spr_r.enabled)
    //        {
    //            if(classicGame.currentPhase==classicGame.RoundConfirmation)
    //            {
    //                classicGame.currentPhase = classicGame.RoundAnnouncement;
    //                spr_r.enabled=false;
    //            }
    //            else
    //            {
    ////				gameFlag.isGameStarted=true;
    ////				gameFlag.isSelectionStarted=false;
    ////				spr_r.enabled=false;
    ////				classicGame.enabled=true;
    ////				classicGame.ScriptStart(JesterNames, JesterCounter);
    //            }
    //        }
    //    }

    public void CheckReady()
    {

        if (JesterNames.Length > 1)
        {
            allReady = true;
            //Debug.Log(JesterNames.Length);
            for (int i = 0; i < JesterNames.Length; i++)
            {
                string Name = JesterNames[i];
                //Name=Name[6].ToString();
                //Debug.Log(Name.Length);
                if (Name.Length > 4)
                {

                    if (!GameObject.Find("button P" + Name[6]).GetComponent<PressToSpawn>().isReady)
                    {
                        allReady = false;
                        break;

                    }
                }
            }
        }
    }
}
