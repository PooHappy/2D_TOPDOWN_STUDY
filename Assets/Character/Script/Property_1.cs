using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property_1 : MonoBehaviour
{
    Property mySalary = new Property();

    private void Start()
    {
        print(mySalary.salary);
    }
}
