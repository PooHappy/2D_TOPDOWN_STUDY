using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 델리게이트_2 : MonoBehaviour
{
    public void ABC(int value)
    {
        print(value + "값이 증가하였습니다.");
    }
    // Start is called before the first frame update
    void Start()
    {
        델리게이트.OnStart += ABC;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
