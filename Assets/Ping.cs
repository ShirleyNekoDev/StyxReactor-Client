using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    public float DestroyDelay;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
