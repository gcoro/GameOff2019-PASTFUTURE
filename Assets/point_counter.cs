using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class point_counter : MonoBehaviour
{
    public Text txt;
    public string settedPoints = "0";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Punteggio: " + settedPoints;
    }

    public void collisionDetected()
    {
        settedPoints = Time.time.ToString().Split(',')[0];
    }

}
