using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collision_detector : MonoBehaviour
{

    public UnityEvent collisionHappended = new UnityEvent();
    
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
            collisionHappended.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
