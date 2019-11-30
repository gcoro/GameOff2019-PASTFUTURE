using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_movement : MonoBehaviour
{
    private bool isDead = false;
    private UnityEngine.Transform lastVisibleChildren;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        List<UnityEngine.Transform> visibleChildrens = new List<UnityEngine.Transform>();
        List<UnityEngine.Transform> notVisibleChildrens = new List<UnityEngine.Transform>();
        foreach (Transform child in transform)
        {
            if (!child.GetComponent<Renderer>().isVisible)
            {
                notVisibleChildrens.Add(child);
            }
            else
            {
                visibleChildrens.Add(child);
            }
        }
        if (visibleChildrens.Count > 1) // transition between two stages, do nothing
        {
            return;
        }
        else if (visibleChildrens.Count == 1)
        {
            if (!lastVisibleChildren || visibleChildrens[0].gameObject.name != lastVisibleChildren.gameObject.name)
            {
                lastVisibleChildren = visibleChildrens[0];
                moveObjects(lastVisibleChildren, notVisibleChildrens[0]);
            }
        }
    }

    void moveObjects(UnityEngine.Transform current, UnityEngine.Transform next)
    {
        next.transform.position = current.transform.position + new Vector3(current.GetComponent<Renderer>().bounds.size.x, 0, 0);
    }

    public void collisionDetected()
    {
        isDead = true;
    }
}

