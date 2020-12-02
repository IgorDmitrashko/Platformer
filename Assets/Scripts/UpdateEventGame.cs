using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateEventGame : MonoBehaviour
{    
    public UnityEvent unity;

    public void UpdateConfigeration() {      
        unity?.Invoke();       
    }
}
