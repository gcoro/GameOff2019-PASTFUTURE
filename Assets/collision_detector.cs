using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collision_detector : MonoBehaviour
{

    public UnityEvent collisionHappended = new UnityEvent();
    private bool isColliderActive = true;
    private float gracePeriod = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("collision happened");
            //If the GameObject's name matches the obstacle, notify
            if (isColliderActive)
            collisionHappended.Invoke();
        }
    }

    void swapDetected()
    {
        isColliderActive = false;
        StartCoroutine(WaitForColliderEnable());
        new WaitForSeconds(2);
    }

    IEnumerator WaitForColliderEnable()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(gracePeriod);
        isColliderActive = true;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
