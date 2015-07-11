using UnityEngine;
using System.Collections;

public class BulbScript : MonoBehaviour
{

    ClassicGameScript GameScript;
    public GameObject matchManager;
    bool roundEnded;
	GameObject tempBulb;
    // Use this for initialization
    void Start()
    {
        GameScript = (ClassicGameScript)matchManager.GetComponent(typeof(ClassicGameScript));
        roundEnded = GameScript.RoundEnded;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] bulb = GameObject.FindGameObjectsWithTag("bulb");

        for (int i = 0; i < bulb.Length; i++)
        {
			tempBulb = GameObject.Find ("Bulb"+(i+1).ToString());
                    if (GameScript.timer > GameScript.RoundDuration * (i+1) / 40)
                    {
				//	Debug.Log("change");
                        Color color = Color.black;
                        tempBulb.GetComponent<Renderer>().material.color = color;
                    }
					else
					{
						Color color = Color.yellow;
						tempBulb.GetComponent<Renderer>().material.color = color;
					}   
        }
    }
}
