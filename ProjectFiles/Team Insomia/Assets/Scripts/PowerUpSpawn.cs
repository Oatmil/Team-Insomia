using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour {

    public GameObject m_shirnk;
    public GameObject m_grow;

    public float delayTimer;
    float m_delayTimer;
    Vector3 spawnRandom;
    float spawnNumber =0;
	ClassicGameScript classicGame;

	gotoStartGame checkGameStart;
	// Use this for initialization
	void Start () {
		checkGameStart = GameObject.Find ("Main Camera").GetComponent<gotoStartGame> ();
		classicGame = GameObject.Find("MatchManager").GetComponent<ClassicGameScript>();
		
        m_delayTimer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (checkGameStart.isGameStarted == true) {
			if(classicGame.currentPhase == classicGame.Round){
			spawnNumber = Random.Range (0, 2);
			//Debug.Log(spawnNumber);
			if (delayTimer <= 0) {
            
				if (spawnNumber == 0) {
					spawnRandom = new Vector3 (Random.Range (-2.5f, 2.5f), 24f, Random.Range (-2f, 2.8f));
					GameObject shrink1 = GameObject.Instantiate (m_shirnk, spawnRandom, Quaternion.identity) as GameObject;
					shrink1.transform.eulerAngles = new Vector3 (Random.Range (25,65),Random.Range (25,65),Random.Range (25,65));
					delayTimer = m_delayTimer;
				}
				if (spawnNumber == 1) {
					spawnRandom = new Vector3 (Random.Range (-2.5f, 2.5f), 24f, Random.Range (-2f, 2.8f));
					GameObject grow1 = GameObject.Instantiate (m_grow, spawnRandom, Quaternion.identity) as GameObject;
					grow1.transform.eulerAngles = new Vector3 (Random.Range (25,65),Random.Range (25,65),Random.Range (25,65));
					delayTimer = m_delayTimer;
				}
            
			}
			delayTimer -= Time.deltaTime;
			}		
		}
	}
}
