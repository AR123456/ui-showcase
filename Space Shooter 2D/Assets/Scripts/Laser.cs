using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed variable of 8 
    [SerializeField]
    private float _lzspeed = 8;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // laser behavior here - move up infinantly 
        // transform of laser
        transform.Translate(Vector3.up*Time.deltaTime);
    }
}
