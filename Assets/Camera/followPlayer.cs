using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform playerReference;
    public Vector3 offset;    
    
    // Update is called once per frame
    void Update()
    {
        transform.position = playerReference.position + offset;    
    }
}