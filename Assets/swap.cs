using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class swap : MonoBehaviour
{

    private bool isKeyPressed = false;
    private float lastTime = 0;
    private float delay = 4f;
    private float normalWorldDelay = 8f;
    private bool isDead = false;
    public UnityEvent swapHappened = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.lastTime != 0 && ((isKeyPressed && Time.time - lastTime < delay)|| (!isKeyPressed &&  Time.time - lastTime < normalWorldDelay)) || isDead)
            return;
        if (!isKeyPressed && Input.GetKeyDown("e"))
        {
            if (gameObject.name.Contains("_alternative"))
            {
                transform.position = transform.position + new Vector3(0, 0, -89);
            }
            else
            {
                transform.position = transform.position + new Vector3(0, 0, +89);
            }
            this.lastTime = Time.time;
            swapHappened.Invoke();
            this.isKeyPressed = true;
        }
        else if (isKeyPressed)
        {
            if (gameObject.name.Contains("_alternative"))
            {
                transform.position = transform.position + new Vector3(0, 0, +89);
            }
            else
            {
                transform.position = transform.position + new Vector3(0, 0, -89);
            }
            this.lastTime = Time.time;
            swapHappened.Invoke();
            this.isKeyPressed = false;
        }
    }

    public void collisionDetected()
    {
            isDead = true;
    }
}
