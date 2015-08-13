using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour
{

    public float effectTime;
    Rigidbody rb;

    float defaultmass;
    float defaulttime;
    Vector3 defaultsize;
    float differentForce;

    bool takeneffect = false;

    RotateController Controller;
    // Use this for initialization
    void Start()
    {
        Controller = GetComponent<RotateController>();
        rb = GetComponent<Rigidbody>();
        defaultmass = rb.mass;
        defaulttime = effectTime;
        defaultsize = transform.localScale;
        Controller.m_pickUpMovespeedmodifier = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (takeneffect == true)
        {
            effectTime -= Time.deltaTime;
            if (effectTime <= 0 || transform.position.y <= -15f)
            {
                takeneffect = false;
                rb.mass = defaultmass;
                Controller.m_pickUpMovespeedmodifier = 1.0f;
                transform.localScale = defaultsize;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.name)
        {

            case "Shrink(Clone)":

                rb.mass = 0.6f;
                transform.localScale = new Vector3(0.4f, defaultsize.y, 0.4f);
                Controller.m_pickUpMovespeedmodifier = 0.5f;
                takeneffect = true;
                Destroy(col.gameObject);
                break;

            case "Grow(Clone)":
                rb.mass = 1.4f;
			    transform.localScale = new Vector3(0.9f, defaultsize.y, 0.9f);
                Controller.m_pickUpMovespeedmodifier = 1.5f;
                takeneffect = true;
                Destroy(col.gameObject);
                break;
        }
        effectTime = defaulttime;
    }
}
