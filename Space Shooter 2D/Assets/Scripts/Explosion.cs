using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
      
        // called at Explosion start so destroy
        Destroy(this.gameObject, 3f);
               
    }

   
}
