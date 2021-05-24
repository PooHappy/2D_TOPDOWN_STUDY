using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Human
{
    string schoolName;

    void Start()
    {
        schoolName = "대학교";
        humanName = "김길동";
        humanAge = 20;

        Info();
    }
    protected override void Info()
    {
        base.Info();  //Human에 있는 Info
        print("학생");
    }
    protected override void Name()
    {
        print(humanName);
    }
}
