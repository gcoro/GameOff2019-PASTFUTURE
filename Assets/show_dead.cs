using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_dead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collisionDetected()
    {
        gameObject.SetActive(true);
    }
}
