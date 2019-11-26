using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public float startTime = 0;
    public float duration = 2;

    public Slider slider;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && ((startTime + duration) < Time.time || startTime == 0))
        {
            startTime = Time.time;
            slider.value = 1;

        }
        else if (startTime > 0 && ((startTime + duration) > Time.time))
        {
            slider.value = (Time.time - startTime) / duration;
        }
        else
        {
            slider.value =1;
        }
    }
}
