using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swap : MonoBehaviour
{

    private bool isKeyPressed = false;
    private float lastTime = 0;
    private float delay = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.lastTime != 0 && Time.time - this.lastTime < delay)
            return;
        if (Input.GetKeyDown("e")){
            if (!this.isKeyPressed)
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
                this.isKeyPressed = true;
            } else {
                if (gameObject.name.Contains("_alternative"))
                {
                    transform.position = transform.position + new Vector3(0, 0, +89);
                }
                else
                {
                    transform.position = transform.position + new Vector3(0, 0, -89);
                }
                this.lastTime = Time.time;
                this.isKeyPressed = false;

            }
        }
    }
}
