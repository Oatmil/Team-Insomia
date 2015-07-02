using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour
{

    public float effectTime;
    Rigidbody rb;

    float defaultmass;
    float defaulttime;
    Vector3 defaultsize;
    bool takeneffect = false;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultmass = rb.mass;
        defaulttime = effectTime;
        defaultsize = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (takeneffect == true)
        {
            effectTime -= Time.deltaTime;
            if (effectTime <= 0)
            {
                takeneffect = false;
                rb.mass = defaultmass;
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
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                takeneffect = true;
                Destroy(col.gameObject);
                break;

            case "Grow(Clone)":
                rb.mass = 1.4f;
                transform.localScale = new Vector3(1f, 1f, 1f);
                takeneffect = true;
                Destroy(col.gameObject);
                break;
        }
        effectTime = defaulttime;
    }
}
