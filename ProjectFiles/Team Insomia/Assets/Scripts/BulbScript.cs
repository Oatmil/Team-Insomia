using UnityEngine;
using System.Collections;

public class BulbScript : MonoBehaviour
{

    ClassicGameScript GameScript;
    public GameObject matchManager;
    bool roundEnded;
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
            switch (bulb[i].name)
            {
                case "Bulb1":
                    if (GameScript.timer > GameScript.RoundDuration * 1 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
					else
					{
						Color color = Color.yellow;
						bulb[i].GetComponent<Renderer>().material.color = color;
					}
                    break;
                case "Bulb2":
                    if (GameScript.timer > GameScript.RoundDuration * 2 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb3":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 3 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb4":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 4 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb5":
                    
                    if (GameScript.timer > GameScript.RoundDuration * 5 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb6":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 6 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb7":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 7 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb8":
                  
                    if (GameScript.timer > GameScript.RoundDuration * 8 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb9":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 9 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb10":
                    
                    if (GameScript.timer > GameScript.RoundDuration * 10 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb11":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 11 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb12":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 12 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb13":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 13 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb14":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 14 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb15":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 15 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb16":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 16 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb17":
                    
                    if (GameScript.timer > GameScript.RoundDuration * 17 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb18":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 18 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb19":
                    
                    if (GameScript.timer > GameScript.RoundDuration * 19 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb20":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 20 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb21":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 21 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb22":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 22 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb23":
                  
                    if (GameScript.timer > GameScript.RoundDuration * 23 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb24":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 24 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb25":
                    
                    if (GameScript.timer > GameScript.RoundDuration * 25 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb26":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 26 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb27":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 27 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb28":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 28 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb29":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 29 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb30":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 30 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb31":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 31 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb32":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 32 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb33":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 33 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb34":
                    
                    if (GameScript.timer > GameScript.RoundDuration * 34 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb35":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 35 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb36":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 36 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb37":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 37 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb38":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 38 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb39":
                   
                    if (GameScript.timer > GameScript.RoundDuration * 39 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
                case "Bulb40":
                  
                    if (GameScript.timer > GameScript.RoundDuration * 40 / 40)
                    {
                        Color color = Color.black;
                        bulb[i].GetComponent<Renderer>().material.color = color;
                    }
				else
				{
					Color color = Color.yellow;
					bulb[i].GetComponent<Renderer>().material.color = color;
				}
                    break;
            }
        }
    }
}
