using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_platform : MonoBehaviour
{
    public GameObject otherObj;
    private bool lastState;
    void Start()
    {
    }

    void Update()
    {
        if (lastState != gameObject.GetComponent<Renderer>().isVisible)
        {
            if (gameObject.GetComponent<Renderer>().isVisible)
                otherObj.transform.position = transform.position + new Vector3(gameObject.GetComponent<Renderer>().bounds.size.x, 0, 0);
           else if (!otherObj.GetComponent<Renderer>().isVisible)
            {
                otherObj.transform.position = transform.position + new Vector3(gameObject.GetComponent<Renderer>().bounds.size.x, 0, 0);
            }
        }
    }
}
