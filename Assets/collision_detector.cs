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
        yield return new WaitForSeconds(gracePeriod);
        isColliderActive = true;
    }
}
