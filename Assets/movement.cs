using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 0.5f;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        transform.position = transform.position + new Vector3(speed, 0, 0);//*time.deltatime
    }

    public void collisionDetected()
    {
        Debug.Log("Dead movement");
        isDead = true;
    }
}
