using UnityEngine;
using System.Collections;

public class gotoStartGame : MonoBehaviour
{

    public bool isGameStarted = false;
    public bool isSelectionStarted = false;

    public GameObject m_BG;

    Animator myAnime;

    void Start()
    {
        myAnime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelectionStarted == true)
        {
            myAnime.SetBool("gameStart", true);
            if (m_BG.transform.localPosition.z > -1f)
            {
                m_BG.transform.localPosition += new Vector3(0.0f, 0.0f, -0.3f);
            }
        }
    }


}
