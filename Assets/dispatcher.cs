using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispatcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void dispatchCollisionEvent() => BroadcastMessage("collisionDetected");
   public void dispatchSwapEvent() => BroadcastMessage("swapDetected");
}
