using UnityEngine;
using System.Collections;
enum GamePhases { Round, RoundAnnouncement, MatchEnding }
public class ClassicGameScript : MonoBehaviour
{
    public bool RoundEnded = true;
    public int RoundDuration;
    public int numberOfRounds;
    public int AnnouncementTime;
    int currentRound = 0;
    public float timer = 0;
    GamePhases currentPhase = GamePhases.RoundAnnouncement;

    GUIStyle winnerStyle;
    //For resetting purpose at the start of each round
    GameObject[] MovingObjects = new GameObject[5];
    GameObject[] Buttons = new GameObject[4];
    Vector3[] MovingObjectsP = new Vector3[5];
    Spotlight spotlightScript;
    int winnerPlayer = 0;
    void Start()
    {
        winnerStyle = new GUIStyle();
        winnerStyle.normal.textColor = Color.black;
        currentRound = 1;
        //Prepare an array of all moving obejcts
        for (int i = 0; i < 5; i++)
        {
            if (i < 4)
            {
                MovingObjects[i] = GameObject.Find("Jester" + ((i + 1).ToString()));
            }
            else
            {
                MovingObjects[i] = GameObject.Find("/Score_Spotlight");
            }
        }

        //Prepare an array of the starting positions of said objects
        for (int i = 0; i < 5; i++)
        {
            MovingObjectsP[i] = MovingObjects[i].transform.position;
        }

        spotlightScript = GameObject.Find("Score_Spotlight").gameObject.GetComponent<Spotlight>();

        for (int i = 0; i < 4; i++)
        {
            Buttons[i] = GameObject.Find("/button P" + (i + 1).ToString());

        }

    }

    void AnnounceRound()
    {
        currentPhase = GamePhases.RoundAnnouncement;
        timer += Time.deltaTime;
        for (int i = 0; i < 4; i++)
        {
            Buttons[i].GetComponent<PressToMove>().P1isPressed = false;
        }
        if (timer > AnnouncementTime)
        {
            RoundEnded = false;
            timer = 0;
            currentPhase = GamePhases.Round;
        }


    }
    void UpdateRound()
    {
        timer += Time.deltaTime;
        //round ended
        if (timer > RoundDuration)
        {
            timer = 0;
            currentRound++;
            //RoundEnded = true;
            if (currentRound <= numberOfRounds)
                currentPhase = GamePhases.RoundAnnouncement;
            else
                currentPhase = GamePhases.MatchEnding;
            for (int i = 0; i < 4; i++)
            {
                Buttons[i].GetComponent<PressToMove>().P1isPressed = false;
            }
            for (int i = 0; i < 5; i++)
            {
                if (MovingObjects[i])
                {
                    MovingObjects[i].transform.position = MovingObjectsP[i];
                    if (MovingObjects[i].GetComponent<Rigidbody>())
                        MovingObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            spotlightScript.parentPlayer = null;
            spotlightScript.gameObject.transform.parent = null;


        }
    }
    bool announcedPlayer = false;
    void EndMatch()
    {
        if (!announcedPlayer)
        {
            winnerPlayer = 1;
            for (int i = 0; i < 4; i++)
            {
                if (MovingObjects[i].GetComponent<Scoring>().score > MovingObjects[winnerPlayer - 1].GetComponent<Scoring>().score)
                {

                    winnerPlayer = i + 1;

                }
            }
            switch (winnerPlayer)
            {
                case 1:

                    winnerStyle.normal.textColor = Color.red;
                    break;

                case 2:
                    winnerStyle.normal.textColor = new Color(0, 1f, 0.876f);
                    break;
                case 3:
                    winnerStyle.normal.textColor = new Color(0.996f, 0.298f, 0.996f);
                    break;
                case 4:
                    winnerStyle.normal.textColor = new Color(0.627f, 1f, 0.129f);
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                Buttons[i].GetComponent<PressToMove>().P1isPressed = false;
            }


            for (int i = 0; i < 5; i++)
            {
                if (MovingObjects[i])
                {
                    MovingObjects[i].transform.position = MovingObjectsP[i];
                    if (MovingObjects[i].GetComponent<Rigidbody>())
                        MovingObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }
        announcedPlayer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentPhase == GamePhases.RoundAnnouncement)
            AnnounceRound();
        else if (currentPhase == GamePhases.Round)
            UpdateRound();
        else if (currentPhase == GamePhases.MatchEnding)
            EndMatch();

    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 60;
        if (currentPhase == GamePhases.RoundAnnouncement)
        {
            GUI.Label(new Rect(Screen.width / 3, Screen.height / 3, 400, 400), "Round " + (currentRound.ToString()));
        }
        else if (currentPhase == GamePhases.Round)
        {
            GUI.Label(new Rect(Screen.width/9 , Screen.height / 3, 150, 400), "Time " + (((int)(RoundDuration - timer + 1)).ToString()));
        }
        else if (currentPhase == GamePhases.MatchEnding)
        {

            winnerStyle.fontSize = 60;
            GUI.Label(new Rect(Screen.width / 5, Screen.height / 5, 200, 200), "Winner is: Player " + (winnerPlayer.ToString()), winnerStyle);
        }
    }
}
