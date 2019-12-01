using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class return_start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        SceneManager.LoadScene("StartScene");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("StartScene");
    }
}
