using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive : MonoBehaviour
{
    //public Canvas can;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deactivate(Canvas can)
    {
        can.enabled = false;
    }
}
