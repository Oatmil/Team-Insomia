using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressToSpawn : MonoBehaviour
{
    gotoStartGame gameFlag;
    public GameObject JesterToThis;
    PressToMove moveScript;
    StartGameOnReadyOrTouch StartScript;
    RotateController RC;
    [HideInInspector]
    public bool isReady;
    //Text ReadyText;
    public GameObject UndoSpawnCanvasButton;
    [HideInInspector]
    public bool spawnedJester = false;
    //public GameObject TextElementToThis;
    public GameObject ReadyOn;
    public GameObject ReadyOff;
    Image ReadyImageOn;
    Image ReadyImageOff;
    public GameObject ButtonImage;
    bool loadedSprites = false;
    ClassicGameScript classicGame;

    [HideInInspector]
    public Vector3 DefaultRotation;

    // Use this for initialization
    void Start()
    {
        classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();
        gameFlag = GameObject.Find("Main Camera").GetComponent<gotoStartGame>();
        moveScript = gameObject.GetComponent<PressToMove>();
        moveScript.enabled = false;
        StartScript = GameObject.Find("ui_btn_start").GetComponent<StartGameOnReadyOrTouch>();
        RC = JesterToThis.GetComponent<RotateController>();
        ReadyOn.SetActive(true);
        ReadyOff.SetActive(true);
        DefaultRotation = JesterToThis.transform.eulerAngles;

        //		ReadyText =TextElementToThis.GetComponent<Text>();
        //		ReadyText.text = "Not Ready";
        //		ReadyText.color = new Color(255,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameFlag.isSelectionStarted||classicGame.currentPhase == classicGame.RoundAnnouncement)
        {
            RC.speed = 0;
            RC.transform.eulerAngles = DefaultRotation;
            moveScript.enabled = false;
            if (!loadedSprites)
            {
                loadedSprites = true;
                ReadyImageOn = ReadyOn.GetComponent<Image>();
                ReadyImageOff = ReadyOff.GetComponent<Image>();
            }
            if (isReady == true)
            {
                //				ReadyText.text = "Ready";
                //				ReadyText.color = new Color(0,0,255);
                ReadyImageOn.enabled = true;
                ReadyImageOff.enabled = false;
                ButtonImage.SetActive(false);
            }
            if (isReady == false)
            {
                //				ReadyText.text = "Not Ready";
                //				ReadyText.color = new Color(255,0,0);
                ReadyImageOn.enabled = false;
                ReadyImageOff.enabled = true;
                ButtonImage.SetActive(false);
            }
        }
        if (gameFlag.isGameStarted)
        {
            //RC.speed=200;
            //Debug.Log(" RC " + RC.speed);
            moveScript.enabled = true;
            if (StartScript.round1Started || classicGame.currentPhase == classicGame.Round)
            {
                ReadyImageOn.enabled = false;
                ReadyImageOff.enabled = false;
                ButtonImage.SetActive(true);
            }
            //	ReadyText.color= new Color(0,0,0);
        }
        if (StartScript.isActiveAndEnabled)
            StartScript.CheckReady();
    }
    void OnTouchDown()
    {
        if (!StartScript.round1Started || classicGame.currentPhase == classicGame.RoundAnnouncement)
        {

            if (!spawnedJester && classicGame.currentRound  == 1)
            {
                if (!JesterToThis.activeSelf)
                {
                    JesterToThis.SetActive(true);
                    StartScript.JesterCounter++;
                    StartScript.JesterNames[StartScript.JesterCounter - 1] = JesterToThis.name;
                    spawnedJester = true;
                    UndoSpawnCanvasButton.SetActive(true);
                }
            }
            if (spawnedJester)
            {
                //if(!isReady)
                isReady = true;
                //else isReady=false;

            }
            //Setting Ready or Not Ready after spawning Jester
        }
    }
    void OnTouchUp()
    {
        isReady = false;
    }
}
