using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(speed,0,0);//*time.deltatime
    }
}
