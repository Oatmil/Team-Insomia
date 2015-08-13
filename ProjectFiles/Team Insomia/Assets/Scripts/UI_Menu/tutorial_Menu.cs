using UnityEngine;
using System.Collections;

public class tutorial_Menu : MonoBehaviour
{

    Animator tutorAnim;

    void Start()
    {
        tutorAnim = GameObject.Find("MainMenu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        tutorAnim.SetBool("startTutorialPlay", true);

    }

}
