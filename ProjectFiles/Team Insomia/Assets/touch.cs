using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {


    public GameObject m_Sphere;
    public GameObject m_parent;
    int countSphere;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            countSphere += 1589;
            Vector3 touchPos = Input.GetTouch(0).position;
            Vector3 createPos = Camera.main.ScreenToWorldPoint(new Vector3 (touchPos.x,touchPos.y,4));
            GameObject object1 = Instantiate(m_Sphere, createPos, Quaternion.identity)as GameObject;
            object1.transform.parent = m_parent.transform;
        }
	}

    void OnGUI()
    {
        GUI.Box(new Rect(100,100,200,60), countSphere.ToString());
    }
}
