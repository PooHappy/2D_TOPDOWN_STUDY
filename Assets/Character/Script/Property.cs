using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{
    public int salary { 
        get { return salary; } 
        private set { salary = value; } 
    }
    /*
    public int salary { 
        get { return salary + bonus; } 
        private set { if(salary < 0) salary = 10; else salary = value; } 
    }
    */
    public int bonus { get; set; }


    private void Start()
    {
        salary = 10;
    }

}
