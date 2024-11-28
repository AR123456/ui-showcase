using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // laser behavior here - move up infinantly 
        transform.position = new Vector3(0, Mathf.Sin(Time.time), 0);
    }
}
