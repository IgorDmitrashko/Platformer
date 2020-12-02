using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Saw : MonoBehaviour
{   
    private void Spin() {
        transform.Rotate(new Vector3(0,0,1));
    }
     // Update is called once per frame
    void Update()
    {
        Spin();
    }  
}
