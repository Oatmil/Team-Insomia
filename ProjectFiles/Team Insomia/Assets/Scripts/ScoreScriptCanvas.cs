using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScriptCanvas : MonoBehaviour {

    public GameObject JesterToScore;
    Text scoreText;
    Scoring Scoring;
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Scoring = (Scoring)JesterToScore.GetComponent(typeof(Scoring));
        scoreText.text = Scoring.score.ToString();
        Debug.Log(Scoring.score.ToString());
	}
}
