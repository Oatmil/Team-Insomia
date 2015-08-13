using UnityEngine;
using System.Collections;

public class credit_Menu : MonoBehaviour
{

    Animator creditAnimator;


    void Start()
    {

        creditAnimator = GameObject.Find("MainMenu").GetComponent<Animator>();

    }
    void OnMouseDown()
    {
        creditAnimator.SetBool("startCreditPlay", true);
    }

    void Update()
    {
        if (this.creditAnimator.GetCurrentAnimatorStateInfo(0).IsName("AllDone"))
        {
            creditAnimator.SetBool("startCreditPlay", false);
        }
    }
}
