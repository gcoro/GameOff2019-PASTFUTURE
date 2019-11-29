using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento_casuale : MonoBehaviour
{
    public GameObject replacementPlatform;
    private UnityEngine.Transform lastVisibleChildren;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void moveObects(UnityEngine.Transform current, UnityEngine.Transform next)
    {
        next.transform.position = current.transform.position + new Vector3(current.GetComponent<Renderer>().bounds.size.x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        List<UnityEngine.Transform> visibleChildrens = new List<UnityEngine.Transform>();
        List<UnityEngine.Transform> notVisibleChildrens = new List<UnityEngine.Transform>();
        foreach (Transform child in transform) {
            if (!child.GetComponent<Renderer>().isVisible)
            {
                notVisibleChildrens.Add(child);
            } else {
                visibleChildrens.Add(child);
            }
        }
        if (visibleChildrens.Count > 1) // transition between two stages, do nothing
        {
            return;
        } else if (visibleChildrens.Count==1)
        {
            if (!lastVisibleChildren || visibleChildrens[0].gameObject.name != lastVisibleChildren.gameObject.name)
            {
                lastVisibleChildren = visibleChildrens[0];
                int rInt = Random.Range(0, notVisibleChildrens.Count);
                moveObects(lastVisibleChildren, notVisibleChildrens[rInt]);
            }
        }

    }

    void swapDetected()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform childChild in child)
            {
                childChild.gameObject.SetActive(!childChild.gameObject.active);
            }
        }
    }
}
